using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampManager : MonoBehaviour
{
    [System.Serializable]
    public struct Stamp
    {
        public Texture2D tex;
        public Material mat;
        public Mesh mesh;
    }

    public GameObject stampViewer;
    Stamp viewedStamp;
    public GameObject stamePagePrefab;

    List<GameObject> stampPages = new List<GameObject>();
    int currentPage = 0;

    public List<Stamp> stamps = new List<Stamp>();
    int createdStamps = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        UpdateStampList();
    }

    void UpdateStampList()
    {
        while (createdStamps < stamps.Count)
        {
            if(createdStamps % 6 == 0)
            {
                stampPages.Add(Instantiate(stamePagePrefab, transform));
            }

            stampPages[stampPages.Count - 1].GetComponent<setStampPreviews>().AddStampPreview(stamps[createdStamps]);
            createdStamps++;
        }
    }

    public void UpdateStampViewer(Stamp selectedStamp)
    {
        viewedStamp = selectedStamp;
        stampViewer.GetComponent<SpriteRenderer>().sprite = Sprite.Create(selectedStamp.tex, new Rect(0, 0, selectedStamp.tex.width, selectedStamp.tex.height), new Vector2(0.5f, 0.5f));
    }
}
