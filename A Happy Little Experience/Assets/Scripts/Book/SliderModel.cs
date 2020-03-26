using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class FloatEvent : UnityEvent<float>
{

}

public class SliderModel : MonoBehaviour
{
    public GameObject slider;
    public FloatEvent ValueChanged;
    [SerializeField] float value;
    [SerializeField] Vector3 local_pos;

    private void ChangeValue()
    {
        ValueChanged.Invoke(value);
    }

    public void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            local_pos = this.transform.InverseTransformPoint(contact.point);
            local_pos.y = local_pos.z = 0;
            value = local_pos.x + 0.5f;

            slider.GetComponent<RectTransform>().localPosition = local_pos;//.Set(local_pos.x, 0, 0);

            ChangeValue();
        }
    }
}
