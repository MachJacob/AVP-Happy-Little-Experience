using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCanvas : MonoBehaviour
{
    public GameObject stamp;
    public Transform currStamp;
    private int pos;

    void Start()
    {
        pos = 0;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brush"))
        {
            currStamp = Instantiate(stamp, collision.transform.position, Quaternion.identity).transform;
            currStamp.transform.localScale *= 0.5f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        currStamp.transform.localScale += new Vector3(0, 1, 1) * Time.deltaTime * 0.05f;
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject placed = Instantiate(currStamp.GetComponent<Stamp>().obj, new Vector3(pos, 0, 0), Quaternion.identity);
        pos++;

        currStamp = null;
    }


}
