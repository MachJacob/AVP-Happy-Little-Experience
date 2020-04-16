using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highfive : MonoBehaviour
{
    public static bool isHighfive;
    public static bool stopHighfive;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Anchor")
        {
            if (isHighfive)
            {
                isHighfive = false;
                stopHighfive = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
