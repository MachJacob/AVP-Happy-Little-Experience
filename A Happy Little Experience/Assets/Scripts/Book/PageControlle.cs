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
        //deactivate all pages
        menu.SetActive(false);
        stamps.SetActive(false);
        saveload.SetActive(false);
        colourpresets.SetActive(false);
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
        //Activate only the menu
        menu.SetActive(true);
        stamps.SetActive(false);
        saveload.SetActive(false);
        colourpresets.SetActive(false);
    }
}
