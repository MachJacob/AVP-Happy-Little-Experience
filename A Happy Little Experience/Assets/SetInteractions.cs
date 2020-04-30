using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInteractions : MonoBehaviour
{
    // Start is called before the first frame update
    bool palette = true;
    bool sketchbook;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Palette" && inGameEvents.state == (int)GameStates.Pallet && palette)
        {
            Debug.Log("TOUCHED THE PALLET");
            palette = false;
            inGameEvents.pInteract = true;
        }

        if (other.gameObject.tag == "Book" && inGameEvents.state == (int)GameStates.Sketchbook && sketchbook)
        {
            sketchbook = false;
            inGameEvents.sInteract = true;
        }

        if (other.gameObject.tag == "Brush")
        {
            inGameEvents.bInteract = true;
           
        }

        if (other.gameObject.tag == "Highfive")
        {
            if (inGameEvents.isHighfive)
            {
                Debug.Log("Highfive");
                inGameEvents.stopHighfive = true;
            }

        }
    }

}
