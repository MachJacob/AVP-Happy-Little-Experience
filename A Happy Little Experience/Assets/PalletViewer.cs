using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletViewer : MonoBehaviour
{
    List<Color> colours = new List<Color>();
    [SerializeField]
    List<GameObject> colourDisplay = new List<GameObject>();
    public List<Color> Colours   // property
    {
        get { return colours; }   // get method
        set { 
            colours = value;
            UpdateColours();
        }  // set method
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in GetComponentsInChildren<Transform>())
        {
            colourDisplay.Add(item.gameObject);
        }
    }

    // Update is called once per frame
    void UpdateColours()
    {
        
    }
}
