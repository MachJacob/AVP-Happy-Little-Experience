using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampManager : MonoBehaviour
{
    [System.Serializable]
    public struct StampData
    {
        public Texture2D tex;
        public Material mat;
        public GameObject obj;
    }

    public GameObject stamePagePrefab;
    public GameObject stampViewer;
    public GameObject stampPrefab;
    public GameObject stampSpawn;
    StampData viewedStamp;

    List<GameObject> stampPages = new List<GameObject>();
    int currentPage = 0;

    public List<StampData> stamps = new List<StampData>();
    int createdStamps = 0;

    private void OnEnable()
    {
        UpdateStampList();
    }

    void UpdateStampList()
    {
        while (createdStamps < stamps.Count)
        {
            if (createdStamps % 6 == 0)
            {
                stampPages.Add(Instantiate(stamePagePrefab, transform));
            }

            stampPages[stampPages.Count - 1].GetComponent<setStampPreviews>().AddStampPreview(stamps[createdStamps]);
            createdStamps++;
        }
        ChangeStampPage(currentPage);
    }

    public void ChangeStampPageForward()
    {
        if (currentPage < stampPages.Count - 1)
            ChangeStampPage(currentPage + 1);
    }

    public void ChangeStampPageBackward()
    {
        if (currentPage > 0)
            ChangeStampPage(currentPage - 1);
    }


    void ChangeStampPage(int pageNum)
    {
        if (pageNum < 0)
            pageNum = 0;
        if (pageNum >= stampPages.Count)
            pageNum = stampPages.Count - 1;

        currentPage = pageNum;

        for (int i = 0; i < stampPages.Count; i++)
        {
            stampPages[i].SetActive(i == pageNum);
        }
    }

    public void UpdateStampViewer(StampData selectedStamp)
    {
        viewedStamp = selectedStamp;
        stampViewer.GetComponent<SpriteRenderer>().sprite = Sprite.Create(selectedStamp.tex, new Rect(0, 0, selectedStamp.tex.width, selectedStamp.tex.height), new Vector2(0.5f, 0.5f));
    }

    public void MakeStampVarient()
    {
        if (viewedStamp.tex == null)
            return;
        StampData newStamp;
        //create texture based on original texture
        newStamp.tex = new Texture2D(viewedStamp.tex.width, viewedStamp.tex.height);
        newStamp.tex.SetPixels32(viewedStamp.tex.GetPixels32());
        //create new material with new texture
        newStamp.mat = new Material(viewedStamp.mat);
        newStamp.mat.mainTexture = newStamp.tex;

        newStamp.obj = viewedStamp.obj;

        stamps.Add(newStamp);
        UpdateStampList();
        UpdateStampViewer(newStamp);
    }

    public void EditStamp()
    {

    }

    public void SpawnStamp()
    {
        GameObject[] stamps = GameObject.FindGameObjectsWithTag("Stamp");

        foreach (var item in stamps)
        {
            Destroy(item);
        }

        GameObject newStamp = Instantiate(stampPrefab,stampSpawn.transform.position, stampSpawn.transform.rotation);
        newStamp.GetComponent<Stamp>().tex = viewedStamp.mat;
        newStamp.GetComponent<Stamp>().obj = viewedStamp.obj;
    }
}