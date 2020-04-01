using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ButtonModel : MonoBehaviour
{
    public UnityEvent triggerButton;
    public float ButtonHoldTime = 2;

    bool held = false;

    private void Press()
    {
        if (held)
        {
            triggerButton.Invoke();
            held = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!held)
            held = true;
            StartCoroutine(holdButton());
    }

    private void OnTriggerExit(Collider other)
    {
        if(held)
            held = false;
    }

    IEnumerator holdButton()
    {
        held = true;
        yield return new WaitForSeconds(ButtonHoldTime);
        Press();
    }
}
