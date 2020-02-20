using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public bool grab;
    public GameObject held;
    private bool right;

    void Start()
    {
        grab = false;
        if (gameObject.name.Contains("Left"))
        {
            right = false;
        }
        else
        {
            right = true;
        }
        held = null;
    }

    void Update()
    {
        if (held && right && (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || Input.GetKeyDown(KeyCode.Backspace)) && !grab)
        {
            held.GetComponent<GrabBrush>().Drop();
            held = null;
        }
        else if (held && !right && (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Return)) && !grab)
        {
            held.GetComponent<GrabBrush>().Drop();
            held = null;
        }
        grab = false;
    }

    public bool Grab()
    {
        if (right)
        {
            grab = true;
            return (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || Input.GetKeyDown(KeyCode.Backspace));
        }
        else
        {
            grab = true;
            return (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Return));
        }
    }
}
