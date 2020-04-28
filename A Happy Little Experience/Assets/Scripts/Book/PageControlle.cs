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

    public GameObject menuFront;
    public GameObject menuBack;
    public GameObject stampsFront;
    public GameObject stampsBack;
    public GameObject saveloadFront;
    public GameObject saveloadBack;
    public GameObject colourpresetsFront;
    public GameObject colourpresetsBack;

    public void OpenPage(PAGES openTo)
    {
        menuFront.SetActive(false);
        menuBack.SetActive(false);
        stampsFront.SetActive(false);
        stampsBack.SetActive(false);
        saveloadFront.SetActive(false);
        saveloadBack.SetActive(false);
        colourpresetsFront.SetActive(false);
        colourpresetsBack.SetActive(false);
        
        //reactivate only the required page
        switch (openTo)
        {
            case PAGES.MENU:
                menuFront.SetActive(true);
                menuBack.SetActive(true);
                break;
            case PAGES.STAMPS:
                stampsFront.SetActive(true);
                stampsBack.SetActive(true);
                break;
            case PAGES.SAVELOAD:
                saveloadFront.SetActive(true);
                saveloadBack.SetActive(true);
                break;
            case PAGES.CLOURPRESETS:
                colourpresetsFront.SetActive(true);
                colourpresetsBack.SetActive(true);
                break;
            default:
                menuFront.SetActive(true);
                menuBack.SetActive(true);
                break;
        }
    }

    private void Start()
    {
        OpenPage(PAGES.MENU);
    }
}
