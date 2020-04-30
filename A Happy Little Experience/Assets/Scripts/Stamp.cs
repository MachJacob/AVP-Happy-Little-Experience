using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : MonoBehaviour
{
    public Material tex;
    public GameObject obj;

    private void PlaceStamp()
    {
        Vector3 pos = Vector3.zero;
        GameObject instance = Instantiate(obj, pos, Quaternion.identity);
    }
}
