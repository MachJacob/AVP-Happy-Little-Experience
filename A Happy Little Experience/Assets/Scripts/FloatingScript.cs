using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScript : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float travelTime;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 currentPosition = Vector3.Lerp(start.position, end.position, Mathf.Cos(Time.time / travelTime * Mathf.PI * 2) * -.5f + .5f);
        GetComponent<Rigidbody>().MovePosition(currentPosition);
    }
}
