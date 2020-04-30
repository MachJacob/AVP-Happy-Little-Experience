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
        CLOURPRESETS,
        VOLUME,
        QUIT
    }

    public GameObject menuFront;
    public GameObject menuBack;
    public GameObject volumeMenuFront;
    public GameObject volumeMenuBack;
    public GameObject quitMenuFront;
    public GameObject quitMenuBack;
    public GameObject stampsFront;
    public GameObject stampsBack;
    public GameObject saveloadFront;
    public GameObject saveloadBack;
    public GameObject colourpresetsFront;
    public GameObject colourpresetsBack;

    public Animator bookAnim;

    public void OpenPage(PAGES openTo)
    {
        menuFront.SetActive(false);
        menuBack.SetActive(false);
        volumeMenuFront.SetActive(false);
        volumeMenuBack.SetActive(false);
        quitMenuFront.SetActive(false);
        quitMenuBack.SetActive(false);
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
                inGameEvents.tabMenuInteract = true;
                bookAnim.SetInteger("state", (int)BookStates.Tab1);
                break;
            case PAGES.STAMPS:
                stampsFront.SetActive(true);
                stampsBack.SetActive(true);
                inGameEvents.tabStampsInteract = true;
                bookAnim.SetInteger("state", (int)BookStates.Tab2);
                break;
            case PAGES.SAVELOAD:
                saveloadFront.SetActive(true);
                saveloadBack.SetActive(true);
                inGameEvents.tabSaveInteract = true;
                bookAnim.SetInteger("state", (int)BookStates.Tab3);
                break;
            case PAGES.CLOURPRESETS:
                colourpresetsFront.SetActive(true);
                colourpresetsBack.SetActive(true);
                inGameEvents.tabPalletInteract = true;
                bookAnim.SetInteger("state", (int)BookStates.Tab4);
                break;
            case PAGES.VOLUME:
                volumeMenuFront.SetActive(true);
                volumeMenuBack.SetActive(true);
                break;
            case PAGES.QUIT:
                quitMenuFront.SetActive(true);
                quitMenuBack.SetActive(true);
                break;
            default:
                menuFront.SetActive(true);
                menuBack.SetActive(true);
                bookAnim.SetInteger("state", (int)BookStates.Tab1);
                break;
        }
        //bookAnim.SetInteger("state", (int)BookStates.Tab5);
    }

    private void Start()
    {
        PageToMenu();
    }
    public void PageToMenu()
    {
        OpenPage(PAGES.MENU);
    }
    public void PageToVolume()
    {
        OpenPage(PAGES.VOLUME);
    }
    public void PageToQuit()
    {
        OpenPage(PAGES.QUIT);
    }
}
