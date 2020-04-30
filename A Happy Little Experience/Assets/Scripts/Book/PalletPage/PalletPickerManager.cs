using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletPickerManager : MonoBehaviour
{
    List<Color> colours = new List<Color>();
    [SerializeField] List<GameObject> swatches;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SaveColours()
    {
        colours = GameObject.FindGameObjectWithTag("Palette").GetComponent<PalletManager>().SavePalletSwatches();
        for (int i = 0; i < swatches.Count; i++)
        {
            swatches[i].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", colours[i]);
        }
    }

    public void LoadColours()
    {
        GameObject.FindGameObjectWithTag("Palette").GetComponent<PalletManager>().LoadPalletSwatches(colours);
    }
}
