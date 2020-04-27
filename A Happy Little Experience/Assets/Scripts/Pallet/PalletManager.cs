using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletManager : MonoBehaviour
{
    public List<ColourSwatch> pallet;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public List<Color> SavePalletSwatches()
    {
        List<Color> colours = new List<Color>();
        foreach (var item in pallet)
        {
            colours.Add(item.Colour);
        }

        return colours;
    }

    public void LoadPalletSwatches(List<Color> colours)
    {
        Debug.Log("loading new pallet");
        for (int i = 0; i < pallet.Count; i++)
        {
            pallet[i].Colour = i < colours.Count ? colours[i] : Color.white;
        }
    }
}
