using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CloudData
{
    public Vector3 cloudPos;
    public Vector3 cloudScale;
    public Quaternion cloudRot;
    private bool _isActive;

    public bool isActive
    {
        get
        {
            return _isActive;
        }
    }

    public int x;
    public int y;
    public float distanceFromCam;

    public Matrix4x4 matrix
    {
        get
        {
            return Matrix4x4.TRS(cloudPos, cloudRot, cloudScale);
        }
    }
    public CloudData(Vector3 cloudPos, Vector3 cloudScale, Quaternion cloudRot, int x, int y, float distanceFromCam)
    {
        this.cloudPos = cloudPos;
        this.cloudScale = cloudScale;
        this.cloudRot = cloudRot;
        SetActive(true);
        this.x = x;
        this.y = y;
        this.distanceFromCam = distanceFromCam;
    }

    public void SetActive(bool desState)
    {
        _isActive = desState;
    }


}

public class CloudGeneration : MonoBehaviour
{
    //Mrshes
    public Mesh cloudMesh;
    public Material cloudMaterial;

    //Cloud variables
    public float cloudSize = 5;
    public float maxScale = 1;

    //Noise
    public float timeScale = 1;
    public float textureScale = 1;
    public float minNoiseSize = 0.5f;
    public float sizeScale = 0.25f;

    public Camera mainCam;
    public int maxDistance;
    public int batchesToCreate;

    private Vector3 prevCameraPos;
    private float offsetX = 1;
    private float offsetY = 1;
    private List<List<CloudData>> batches = new List<List<CloudData>>();
    private List<List<CloudData>> batchesToUpdate = new List<List<CloudData>>();

    private void Start()
    {
        for (int batchesX = 0; batchesX < batchesToCreate; batchesX++)
        {
            for (int batchesY = 0; batchesY < batchesToCreate; batchesY++)
            {
                BuildCloudBatches(batchesX, batchesY);
            }
        }
    }

    private void BuildCloudBatches(int xLoop, int yLoop)
    {
        const int THIRTY_ONE = 31;
        bool markBatch = false;
        List<CloudData> currentBatch = new List<CloudData>();

        for (int x = 0; x < THIRTY_ONE; x++)
        {
            for (int y = 0; y < THIRTY_ONE; y++)
            {
                AddCloud(currentBatch, x + xLoop * THIRTY_ONE, y + yLoop * THIRTY_ONE);
            }
        }

        markBatch = CheckforActiveBatch(currentBatch);
        batches.Add(currentBatch);
        if (markBatch) batchesToUpdate.Add(currentBatch);
    }

    private bool CheckforActiveBatch(List<CloudData> batch)
    {
        foreach (var cloud in batch)
        {
            cloud.distanceFromCam = Vector3.Distance(cloud.cloudPos, mainCam.transform.position);
            if (cloud.distanceFromCam < maxDistance) return true;
        }
        return false;
    }
    private void AddCloud(List<CloudData> currentBatch, int x, int y)
    {
        //New Cloud Pos
        Vector3 position = new Vector3(transform.position.x + x * cloudSize, transform.position.y, transform.position.z + y * cloudSize);
        float distanceToCam = Vector3.Distance(new Vector3(x, transform.position.y, y), mainCam.transform.position);
        currentBatch.Add(new CloudData(position, Vector3.zero, Quaternion.identity, x, y, distanceToCam));
    }

    private void Update()
    {
        MakeNoise();
        offsetX += Time.deltaTime * timeScale;
        offsetY += Time.deltaTime * timeScale;
    }

    void MakeNoise()
    {
        if (mainCam.transform.position == prevCameraPos)
        {
            UpdateBatches();
        }
        else
        {
            prevCameraPos = mainCam.transform.position;
            UpdateBatchList();
            UpdateBatches();
        }
        RenderBatches();
        prevCameraPos = mainCam.transform.position;
    }

    private void UpdateBatches()
    {
        foreach (var batch in batchesToUpdate)
        {
            foreach (var cloud in batch)
            {
                float size = Mathf.PerlinNoise(cloud.x * textureScale + offsetX, cloud.y * textureScale + offsetY);
                if (size > minNoiseSize)
                {
                    float localScaleX = cloud.cloudScale.x;
                    if (!cloud.isActive)
                    {
                        cloud.SetActive(true);
                        cloud.cloudScale = Vector3.zero;
                    }
                    if (localScaleX < maxScale)
                    {
                        ScaleCloud(cloud, 1);

                        //Scale limiter
                        if (cloud.cloudScale.x > maxScale)
                        {
                            cloud.cloudScale = new Vector3(maxScale, maxScale, maxScale);
                        }
                    }
                }
                else if (size < minNoiseSize)
                {
                    float localScaleX = cloud.cloudScale.x;
                    ScaleCloud(cloud, -1);

                    if (localScaleX <= 0.1)
                    {
                        cloud.SetActive(false);
                        cloud.cloudScale = Vector3.zero;
                    }
                }
            }
        }
    }
    private void ScaleCloud(CloudData cloud, int direction)
    {
        cloud.cloudScale += new Vector3(sizeScale * Time.deltaTime * direction, sizeScale * Time.deltaTime * direction, sizeScale * Time.deltaTime * direction);
    }
    private void UpdateBatchList()
    {
        batchesToUpdate.Clear();
        foreach (var batch in batches)
        {
            if (CheckforActiveBatch(batch))
            {
                batchesToUpdate.Add(batch);
            }
        }
    }
    private void RenderBatches()
    {
        foreach (var batch in batchesToUpdate)
        {
            Graphics.DrawMeshInstanced(cloudMesh, 0, cloudMaterial, batch.Select((a) => a.matrix).ToList());
        }
    }
}
