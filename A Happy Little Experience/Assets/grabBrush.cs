using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabBrush : MonoBehaviour
{
    private GameObject childController;
    private bool held;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Return)) && held)
        {
            childController.SetActive(true);
            transform.parent = null;
            held = false;
            transform.position = childController.transform.position;
            childController = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Anchor")
            if ((OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Return)) && !held)
            {
                transform.parent = other.transform;
                childController = other.transform.GetChild(0).gameObject;
                childController.SetActive(false);
                held = true;
                transform.localPosition = Vector3.zero;
            }
    }
}
