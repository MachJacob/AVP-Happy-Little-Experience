using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBrush : MonoBehaviour
{
    private GameObject childController;
    private bool held;
    [SerializeField] private GameObject[] colliding;
    public float rotationOffset;
    public Vector3 offset;
    private bool drop;
    // Start is called before the first frame update
    void Start()
    {
        colliding = new GameObject[2];
        drop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Return)) && !held && colliding[0] && !drop)           //attach left
        {
            transform.parent = colliding[0].transform;
            childController = colliding[0].transform.GetChild(0).gameObject;
            transform.localRotation = Quaternion.AngleAxis(rotationOffset, Vector3.right);
            //childController.SetActive(false);
            held = true;
            transform.localPosition = offset;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            colliding[0].GetComponent<Grabber>().held = gameObject;
        }
        else if ((OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || Input.GetKeyDown(KeyCode.Backspace)) && !held && colliding[1] && !drop) //attach right
        {
            transform.parent = colliding[1].transform;
            childController = colliding[1].transform.GetChild(0).gameObject;
            transform.localRotation = Quaternion.AngleAxis(rotationOffset, Vector3.right);
            //childController.SetActive(false);
            held = true;
            transform.localPosition = offset;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            colliding[1].GetComponent<Grabber>().held = gameObject;
        }
        drop = false;
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

    public void Drop()
    {
        childController.SetActive(true);
        transform.parent = null;
        held = false;
        transform.position = childController.transform.position + offset;
        childController = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        drop = true;
    }
}
