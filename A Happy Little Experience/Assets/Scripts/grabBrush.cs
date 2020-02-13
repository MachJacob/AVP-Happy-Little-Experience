using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabBrush : MonoBehaviour
{
    private GameObject childController;
    private bool held;
    [SerializeField] private GameObject[] colliding;
    public float brushOffset = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        colliding = new GameObject[2];
    }

    // Update is called once per frame
    void Update()
    {
        if ((OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Return) || 
            (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || Input.GetKeyDown(KeyCode.Backspace))) && held)
        {
            childController.SetActive(true);
            transform.parent = null;
            held = false;
            transform.position = childController.transform.position + Vector3.forward * brushOffset;
            childController = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
        else if ((OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Return)) && !held && colliding[0])      //attach left
        {
            transform.parent = colliding[0].transform;
            childController = colliding[0].transform.GetChild(0).gameObject;
            transform.localRotation = Quaternion.AngleAxis(90, Vector3.right);
            //childController.SetActive(false);
            held = true;
            transform.localPosition = Vector3.forward * brushOffset;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        else if ((OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || Input.GetKeyDown(KeyCode.Backspace)) && !held && colliding[1]) //attach right
        {
            transform.parent = colliding[1].transform;
            childController = colliding[1].transform.GetChild(0).gameObject;
            transform.localRotation = Quaternion.AngleAxis(90, Vector3.right);
            //childController.SetActive(false);
            held = true;
            transform.localPosition = Vector3.forward * brushOffset;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Anchor")
        {
            if (other.gameObject.name.Contains("Left"))
            {
                colliding[0] = other.gameObject;
            }
            if (other.gameObject.name.Contains("Right"))
            {
                colliding[1] = other.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Anchor")
        {
            if (other.gameObject.name.Contains("Left"))
            {
                colliding[0] = null;
            }
            if (other.gameObject.name.Contains("Right"))
            {
                colliding[1] = null;
            }
        }
    }
}
