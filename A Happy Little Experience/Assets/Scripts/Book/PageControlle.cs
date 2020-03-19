using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageControlle : MonoBehaviour
{
    public enum PAGES
    {
        MENU,
        STAMPS,
        SAVELOAD,
        CLOURPRESETS
    }

    public GameObject menu;
    public GameObject stamps;
    public GameObject saveload;
    public GameObject colourpresets;

    public void OpenPage(PAGES openTo)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        //reactivate only the required page
        switch (openTo)
        {
            case PAGES.MENU:
                menu.SetActive(true);
                break;
            case PAGES.STAMPS:
                stamps.SetActive(true);
                break;
            case PAGES.SAVELOAD:
                saveload.SetActive(true);
                break;
            case PAGES.CLOURPRESETS:
                colourpresets.SetActive(true);
                break;
            default:
                menu.SetActive(true);
                break;
        }
    }

    private void Start()
    {
        OpenPage(PAGES.MENU);
    }
}
