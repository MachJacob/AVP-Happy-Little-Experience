using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourTrenchController : MonoBehaviour
{
    public GameObject saturationSlider;
    public GameObject valueSlider;

    float hue = 0;
    float saturation = 1;
    float value = 1;

    public void setHue(float val)
    {
        hue = val;
        Color[] saturation_colours = { Color.HSVToRGB(hue, 1, value), Color.HSVToRGB(hue, 0, value) };
        Color[] value_colours = { Color.HSVToRGB(hue, saturation, 1), Color.HSVToRGB(hue, saturation, 0) };

        setSliderGradient(saturation_colours, saturationSlider);
        setSliderGradient(value_colours, valueSlider);
    }

    public void setSaturation(float val)
    {
        saturation = val;
        Color[] colours = { Color.HSVToRGB(hue, saturation, 1), Color.HSVToRGB(hue, saturation, 0) };
        setSliderGradient(colours, valueSlider);
    }

    public void setvalue(float val)
    {
        value = val;
        Color[] colours = { Color.HSVToRGB(hue, 1, value), Color.HSVToRGB(hue, 0, value) };
        setSliderGradient(colours, saturationSlider);
    }

    void setSliderGradient(Color[] colours, GameObject slider)
    {
        Texture2D tex = UnityLibrary.GradientTextureMaker.Create(colours);
        Material mat = slider.GetComponent<MeshRenderer>().material;
        mat.mainTexture = tex;
    }
}
