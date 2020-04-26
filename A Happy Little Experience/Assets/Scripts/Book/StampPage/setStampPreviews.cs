using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setStampPreviews : MonoBehaviour
{
    public List<GameObject> slots;
    List<StampManager.Stamp> stamps = new List<StampManager.Stamp>();

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

    public void AddStampPreview(StampManager.Stamp NewStamp)
    {
        stamps.Add(NewStamp);
        UpdateStampPage();
    }
}
