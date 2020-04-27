using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourTrench : MonoBehaviour
{
    public enum SliderType
    {
        hue,
        saturation,
        value
    }
    public SliderType slider;
    float value = 1;

    private void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Brush")
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Vector2 collison_vector = new Vector2(contact.point.x, contact.point.y);
                Vector3 local_pos = transform.InverseTransformPoint(collison_vector);
                value = local_pos.x + 0.5f;
            }
            switch (slider)
            {
                case SliderType.hue:
                    collision.transform.parent.GetComponent<FreeDraw.DrawingSettings>().setHue(value);
                    transform.parent.GetComponent<ColourTrenchController>().setHue(value);
                    break;
                case SliderType.saturation:
                    collision.transform.parent.GetComponent<FreeDraw.DrawingSettings>().setSaturation(value);
                    transform.parent.GetComponent<ColourTrenchController>().setSaturation(value);
                    break;
                case SliderType.value:
                    collision.transform.parent.GetComponent<FreeDraw.DrawingSettings>().setValue(value);
                    transform.parent.GetComponent<ColourTrenchController>().setvalue(value);
                    break;
                default:
                    break;
            }
        }
    }
}
