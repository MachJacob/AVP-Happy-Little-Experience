using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Animator bookAnim;
    // Start is called before the first frame update


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tab1")
        {
            bookAnim.SetInteger("state", (int)BookStates.Tab1);
        }

        if (collision.gameObject.tag == "Tab2")
        {
            bookAnim.SetInteger("state", (int)BookStates.Tab2);
        }

        if (collision.gameObject.tag == "Tab3")
        {
            bookAnim.SetInteger("state", (int)BookStates.Tab3);
        }

        if (collision.gameObject.tag == "Tab4")
        {
            bookAnim.SetInteger("state", (int)BookStates.Tab4);
        }

        if (collision.gameObject.tag == "Tab5")
        {
            bookAnim.SetInteger("state", (int)BookStates.Tab5);
        }
    }

 
}
