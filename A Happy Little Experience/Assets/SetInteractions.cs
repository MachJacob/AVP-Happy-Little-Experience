using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInteractions : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Palette" && inGameEvents.state == (int)GameStates.Pallet)
        {
            inGameEvents.pInteract = true;
        }

        if (other.gameObject.tag == "Book" && inGameEvents.state == (int)GameStates.Sketchbook)
        {
            inGameEvents.sInteract = true;
        }

        if (other.gameObject.tag == "Brush")
        {
            Destroy(GameObject.FindGameObjectWithTag("sparkles"));
        }
    }

}
