using System.Collections;
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
    IEnumerator welcome;
    public static bool pInteract;
    

    //public bool isPointing;
    // Start is called before the first frame update
    void Start()
    {
        anim_brownie = brownie.GetComponent<Animator>();
        audioSource = brownie.GetComponent<AudioSource>();
        hand = GameObject.FindGameObjectWithTag("Highfive");
        welcome = WelcomeToGame();

    }
    

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.isTips && state == (int)GameStates.Welcome)
        {
            StartCoroutine(WelcomeToGame());
            //play brownie's first line
        }
        if (state == (int)GameStates.Pallet && pInteract)
        {
            //StopCoroutine(WelcomeToGame());
            StartCoroutine(StartPallet());
        }

        if (state == (int)GameStates.DrawSky)
        {
            StartCoroutine(DrawSky());
          
        }

        if (startPointEvent)
        {
            StartCoroutine(StartPoint());
        }

        if (Highfive.isHighfive)
        {
            Instantiate(sparkles, (hand.transform));
            //insert YAY! sound effect for brownie
            //"Looks great!"
            anim_brownie.SetInteger("State", (int)BrownieStates.EndPoint);
        }
    }

    IEnumerator DrawSky()
    {
        audioSource.PlayOneShot(brownieNarration[11]);
        yield return new WaitForSeconds(9F);
        audioSource.PlayOneShot(brownieNarration[12]);
        startPointEvent = true;
    }
    IEnumerator StartPallet()
    {
        audioSource.PlayOneShot(brownieNarration[4]);
        yield return new WaitForSeconds(7F);
        audioSource.PlayOneShot(brownieNarration[5]);
        yield return new WaitForSeconds(4F);
        //Insert highlight of the top slider
        yield return new WaitForSeconds(2F);
        //high second slider
        yield return new WaitForSeconds(1F);
        //highlight third slider
        yield return new WaitForSeconds(3F);
        audioSource.PlayOneShot(brownieNarration[6]);
        yield return new WaitForSeconds(4F);
        audioSource.PlayOneShot(brownieNarration[7]);
        yield return new WaitForSeconds(6F);
        audioSource.PlayOneShot(brownieNarration[8]);
        yield return new WaitForSeconds(10F);
        audioSource.PlayOneShot(brownieNarration[9]);
        yield return new WaitForSeconds(4F);
        //highlight water cube
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(brownieNarration[10]);
        yield return new WaitForSeconds(8f);
        state = (int)GameStates.DrawSky;


    }
   IEnumerator WelcomeToGame()
    {
        //play welcome to the game sound clip
        audioSource.PlayOneShot(brownieNarration[1]);
        yield return new WaitForSeconds(7F); //time to be decided when i record voice.. lol
        audioSource.PlayOneShot(brownieNarration[2]);
        yield return new WaitForSeconds(10f);
        audioSource.PlayOneShot(brownieNarration[3]);
        yield return new WaitForSeconds(6f);
        //insert highlight of the pallet
        state = (int)GameStates.Pallet;
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
