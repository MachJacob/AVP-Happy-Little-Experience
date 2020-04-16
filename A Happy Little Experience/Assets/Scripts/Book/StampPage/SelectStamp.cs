using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStamp : MonoBehaviour
{
    GameObject selectedStamp;

    private void Start()
    {
        selectedStamp = GameObject.FindWithTag("StampPreview");
    }


    private void OnTriggerEnter(Collider other)
    {
        selectedStamp.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
    }

}
