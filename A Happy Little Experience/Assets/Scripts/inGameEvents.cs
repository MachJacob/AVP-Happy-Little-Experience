﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameEvents : MonoBehaviour
{
    public bool startPointEvent;
    Animator anim_brownie;
    public static bool isHighfive;
    public GameObject sparkles;
    GameObject hand;
    public static int state;
   
    AudioSource audioSource;
    public AudioClip[] brownieNarration;
    public GameObject brownie;
    public static bool pInteract;
    public static bool sInteract;
    public static bool tabMenuInteract;
    public static bool tabPalletInteract;
    public static bool tabSaveInteract;
    public static bool tabStampsInteract;
    bool one;
    bool two;
    bool three;
    bool four;
    bool go;
    public ParticleSystem sparkles2;
    GameObject pallete;
    GameObject sketchbook;
    GameObject canvas;

    //public bool isPointing;
    // Start is called before the first frame update
    void Start()
    {
        anim_brownie = brownie.GetComponent<Animator>();
        audioSource = brownie.GetComponent<AudioSource>();
        hand = GameObject.FindGameObjectWithTag("Highfive");
        pallete = GameObject.FindGameObjectWithTag("Palette");
        sketchbook = GameObject.FindGameObjectWithTag("Book");
        state = (int)GameStates.Welcome;
        go = true;

    }
    
 
    // Update is called once per frame
    private void Update()
    {
        if (GameManager.isTips && state == (int)GameStates.Welcome && go)
        {
            go = false;
            StartCoroutine(WelcomeToGame());
            //play brownie's first line
        }
        if (state == (int)GameStates.Pallet && pInteract)
        {
            //StopCoroutine(WelcomeToGame());
            StartCoroutine(StartPallet());
            pInteract = false;
            Destroy(sparkles);
        }

        if (state == (int)GameStates.Sketchbook && sInteract)
        {
            
            StartCoroutine(LearnSketchBook());
            sInteract = false;
            Destroy(sparkles);
        }

        if (state == (int)GameStates.Pallet && pInteract)
        {
            StopCoroutine(WelcomeToGame());
            StartCoroutine(StartPallet());
        }

        if (state == (int)GameStates.Sketchbook && tabMenuInteract)
        {
            one = true;
            tabMenuInteract = false;
            audioSource.Stop();
            audioSource.PlayOneShot(brownieNarration[17]);
        }

        if (state == (int)GameStates.Sketchbook && tabSaveInteract)
        {
            two = true;
            tabSaveInteract = false;
            audioSource.Stop();
            audioSource.PlayOneShot(brownieNarration[20]);
        }

        if (state == (int)GameStates.Sketchbook && tabStampsInteract)
        {
            three = true;
            tabStampsInteract = false;
            audioSource.Stop();
            audioSource.PlayOneShot(brownieNarration[21]);
        }

        if (state == (int)GameStates.Sketchbook && tabPalletInteract)
        {
            four = true;
            tabPalletInteract = false;
            audioSource.Stop();
            audioSource.PlayOneShot(brownieNarration[19]);
        }
        if(one && two && three && four)
        {
            state = (int)GameStates.ObjectPainting;
            StartCoroutine(objectPainting());
        }
        if (state == (int)GameStates.DrawSky)
        {
            StartCoroutine(DrawSky());
          
        }

        if (startPointEvent)
        {
            StartCoroutine(StartPoint());
        }
        if(pInteract || sInteract)
        {
            sInteract = false;
            pInteract = false;
            Destroy(sparkles);
        }

        if (Highfive.isHighfive && Highfive.stopHighfive)
        {
            Highfive.stopHighfive = false;
            Instantiate(sparkles, (hand.transform));
            
            
            audioSource.PlayOneShot(brownieNarration[13]);
            anim_brownie.SetInteger("State", (int)BrownieStates.EndPoint);
            StartCoroutine(StartSketchBook());
            //insert YAY! sound effect for brownie
            //"Looks great!"   
        }
    }
    
    IEnumerator objectPainting()
    {
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(brownieNarration[22]);
        yield return new WaitForSeconds(8f);
        audioSource.PlayOneShot(brownieNarration[23]);
        yield return new WaitForSeconds(7f);
        audioSource.PlayOneShot(brownieNarration[24]);
        yield return new WaitForSeconds(15f);
        audioSource.PlayOneShot(brownieNarration[25]);
        //INSERT DONE BUTTON EVENT HERE???
        yield return new WaitForSeconds(15f);
        audioSource.PlayOneShot(brownieNarration[26]);
        yield return new WaitForSeconds(3f);
        audioSource.PlayOneShot(brownieNarration[27]);
        yield return new WaitForSeconds(5f);
        state = (int)GameStates.NewLoop;
    }


    IEnumerator LearnSketchBook()
    {
        yield return new WaitForSeconds(1f);

        audioSource.PlayOneShot(brownieNarration[17]);
        yield return new WaitForSeconds(1f);


    }

    IEnumerator StartSketchBook()
    {
        state = (int)GameStates.Sketchbook;
        yield return new WaitForSeconds(3f);
        audioSource.PlayOneShot(brownieNarration[15]);
        yield return new WaitForSeconds(5f);
        audioSource.PlayOneShot(brownieNarration[16]);
        playSparkles(sketchbook.transform);
    }
    IEnumerator DrawSky()
    {
        audioSource.clip = brownieNarration[11];
        audioSource.Play();
        yield return new WaitForSeconds(9F);
        audioSource.PlayOneShot(brownieNarration[12]);
        startPointEvent = true;
        Highfive.isHighfive = true;
    }
    IEnumerator StartPallet()
    {
        audioSource.PlayOneShot(brownieNarration[4]);
        yield return new WaitForSeconds(7F);
        audioSource.PlayOneShot(brownieNarration[5]);
        yield return new WaitForSeconds(4F);
        //Insert highlight of the top slider
        yield return new WaitForSeconds(10F);

        audioSource.PlayOneShot(brownieNarration[6]);
        yield return new WaitForSeconds(4F);
        audioSource.PlayOneShot(brownieNarration[7]);
        yield return new WaitForSeconds(6F);
        audioSource.PlayOneShot(brownieNarration[8]);
        yield return new WaitForSeconds(10F);
        audioSource.PlayOneShot(brownieNarration[9]);
        yield return new WaitForSeconds(4F);
        
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(brownieNarration[10]);
        yield return new WaitForSeconds(8f);
        state = (int)GameStates.DrawSky;


    }
   IEnumerator WelcomeToGame()
    {
        yield return new WaitForSeconds(2f);
        //play welcome to the game sound clip
        audioSource.PlayOneShot(brownieNarration[1]);
        yield return new WaitForSeconds(7F); 
        audioSource.PlayOneShot(brownieNarration[2]);
        yield return new WaitForSeconds(10f);
        audioSource.PlayOneShot(brownieNarration[3]);
        yield return new WaitForSeconds(6f);
        playSparkles(pallete.transform);
        state = (int)GameStates.Pallet;
    }

    void playSparkles(Transform transform)
    {
        Instantiate(sparkles, transform);
    }
    IEnumerator StartPoint()
    {
        anim_brownie.SetInteger("State", (int)BrownieStates.StartPoint);
        yield return new WaitForSeconds(1f);
        anim_brownie.SetInteger("State", (int)BrownieStates.MiddlePoint);
        startPointEvent = false;
    }

    void EndPoint()
    {
        anim_brownie.SetInteger("State", (int)BrownieStates.EndPoint);
    }
}
public enum GameStates
{
    Welcome,
    Pallet,
    DrawSky,
    Sketchbook,
    ObjectPainting,
    NewLoop,
}

public enum BrownieStates
{
    Idle,
    StartPoint,
    MiddlePoint,
    EndPoint,
}

public enum BookStates
{
    Closed,
    Tab1,
    Tab2,
    Tab3,
    Tab4,
    Tab5
}
