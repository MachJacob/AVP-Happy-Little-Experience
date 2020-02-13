using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSwatch : MonoBehaviour
{
    public Color colour;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mat.color = colour;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Brush")
        {
            other.transform.parent.gameObject.GetComponent<FreeDraw.DrawingSettings>().SetMarkerColour(colour);
        }        
    }
}
