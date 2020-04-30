using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSelect : MonoBehaviour
{
    public GameObject pageControl;
    public PageControlle.PAGES tabToPage;

    private void OnTriggerEnter(Collider other)
    {
        pageControl.GetComponent<PageControlle>().OpenPage(tabToPage);
    }

}
