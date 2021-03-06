﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSwatch : MonoBehaviour
{
    public float duration_of_lerp;
    private float lerp_progress = 1;

    private Color colour;
    public Color Colour
    {
        get { return colour; }   // get method
        set
        { 
            colour = value;
            mat.SetColor("_BaseColor", colour);
        }  // set method
  }
    private Color new_colour;
    private Material mat;

    private bool setting_colour = false;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        new_colour = colour = mat.GetColor("_BaseColor");
    }

    // Update is called once per frame
    void Update()
    {
        if (setting_colour && lerp_progress <= 1)
        {
            mat.SetColor("_BaseColor", Color.Lerp(colour, new_colour, lerp_progress));
            lerp_progress += Time.deltaTime / duration_of_lerp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Brush")
        {
            FreeDraw.DrawingSettings brush = other.transform.parent.gameObject.GetComponent<FreeDraw.DrawingSettings>();
            if (brush.is_clean)
            {
                brush.SetBrushColour(colour);
            }
            else
            {
                setting_colour = true;
                StartCoroutine(loadColourChange(brush));
            }
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Brush")
        {
            if (setting_colour)
            {
                StopCoroutine("loadColourChange");
                setting_colour = false;
                new_colour = colour = mat.GetColor("_BaseColor");
            }
        }
    }

    IEnumerator loadColourChange(FreeDraw.DrawingSettings brush)
    {
        yield return new WaitForSeconds(0.5f);
        if (setting_colour)
        {
            setting_colour = true;
            lerp_progress = 0;
            new_colour = brush.GetBrushColour();
            Debug.Log("new_colour set");
        }
    }
}
