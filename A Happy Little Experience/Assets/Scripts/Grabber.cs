using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    [SerializeField] private bool grab;
    [SerializeField] private GameObject held;
    [SerializeField] private bool right;

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
        if (grab)
        {
            grab = false;
            return;
        }
        if (held && right && (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || Input.GetKeyDown(KeyCode.Backspace)))
        {
            held.GetComponent<Grabbable>().Drop();
            held = null;
        }
        else if (held && !right && (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Return)))
        {
            held.GetComponent<Grabbable>().Drop();
            held = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Palette" && inGameEvents.state == (int)GameStates.Pallet)
        {
            inGameEvents.pInteract = true;
        }

        if (other.gameObject.tag == "Book" && inGameEvents.state == (int)GameStates.Sketchbook)
        {
            inGameEvents.sInteract = true;
        }
    }


        public bool Grab(GameObject _grab)
    {
        held = _grab;
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
