using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FreeDraw
{
    // Helper methods used to set drawing settings
    public class DrawingSettings : MonoBehaviour
    {
        public int width = 10;
        public Color brushColour = Color.red;

        float hue = 0;
        float saturation = 1;
        float value = 1;


        public bool is_clean = true;

        public Material paint;

        private void Start()
        {
            cleanBrush();
        }

        public void cleanBrush()
        {
            is_clean = true;
            brushColour = Color.white;
            paint.SetColor("_BaseColor", brushColour);
        }

        public void setHue(float _hue)
        {
            hue = _hue;
            SetBrushColour(Color.HSVToRGB(hue, saturation, value));
        }

        public void setSaturation(float _saturation)
        {
            saturation = _saturation;
            SetBrushColour(Color.HSVToRGB(hue, saturation, value));
        }

        public void setValue(float _value)
        {
            value = _value;
            SetBrushColour(Color.HSVToRGB(hue, saturation, value));
        }
        // Changing pen settings is easy as changing the static properties Drawable.Pen_Colour and Drawable.Pen_Width
        public void SetBrushColour(Color new_color)
        {
            brushColour = new_color;
            is_clean = false;
            paint.SetColor("_BaseColor", brushColour);
        }

        public Color GetBrushColour()
        {
            return brushColour;
        }

        // new_width is radius in pixels
        public void SetBrushWidth(int new_width)
        {
            Drawable.Pen_Width = new_width;
        }
        public void SetBrushWidth(float new_width)
        {
            SetBrushWidth((int)new_width);
        }

        public int GetBrushWidth()
        {
            return width;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Respawn")
            {
                cleanBrush();
            }
        }
    }
}