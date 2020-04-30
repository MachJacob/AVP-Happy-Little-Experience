using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScript : MonoBehaviour
{
    [SerializeField] private Vector3 start;
    [SerializeField] private Vector3 end;
    //[SerializeField] private Transform target;
    [SerializeField] private float travelTime = 2f;
    //[SerializeField] private float brushOffset = 0.3f;

    // Use this for initialization
    void Start()
    {
        //Vector3 distanceVector = transform.position - target.position;
        //Vector3 distanceVectorNormalized = distanceVector.normalized;
        //Vector3 targetPosition = (distanceVectorNormalized * brushOffset);
        //transform.position = targetPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 currentPosition = Vector3.Lerp(start, end, Mathf.Cos(Time.time / travelTime * Mathf.PI * 2) * -.5f + .5f);
        GetComponent<Rigidbody>().MovePosition(currentPosition);
    }
}
