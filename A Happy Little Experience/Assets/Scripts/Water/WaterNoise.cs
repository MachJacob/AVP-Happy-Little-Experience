using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterNoise : MonoBehaviour
{
    public float power = 3, scale = 1, timeScale = 1;

    private float offsetX;
    private float offsetY;
    private MeshFilter mf;

    private void Start()
    {
        mf = GetComponent<MeshFilter>();
        CreateNoise();
    }

    private void Update()
    {
        CreateNoise();
        offsetX += Time.deltaTime * timeScale;
        offsetY += Time.deltaTime * timeScale;

    }

    void CreateNoise()
    {
        Vector3[] vertecies = mf.mesh.vertices;
        for (int i = 0; i < vertecies.Length; i++)
        {
            vertecies[i].y = CalculateHeight(vertecies[i].x, vertecies[i].z * power);
        }
        mf.mesh.vertices = vertecies;
    }

    float CalculateHeight(float x, float y)
    {
        float xCord = x * scale + offsetX;
        float yCord = y * scale + offsetY;

        return Mathf.PerlinNoise(xCord, yCord);
    }
}
