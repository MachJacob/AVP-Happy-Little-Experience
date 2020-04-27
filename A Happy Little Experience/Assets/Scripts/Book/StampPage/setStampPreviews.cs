using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setStampPreviews : MonoBehaviour
{
    public List<GameObject> slots;
    List<StampManager.StampData> stamps = new List<StampManager.StampData>();

    // Start is called before the first frame update
    void Start()
    {
        UpdateStampPage();
    }

    public void UpdateStampPage()
    {
        for (int i = 0; i < stamps.Count && i < slots.Count; i++)
        {
            slots[i].GetComponent<SelectStamp>().SetStamp(stamps[i]);
        }
    }

    public void AddStampPreview(StampManager.StampData NewStamp)
    {
        stamps.Add(NewStamp);
        UpdateStampPage();
    }
}
