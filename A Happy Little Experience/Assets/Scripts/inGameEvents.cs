using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameEvents : MonoBehaviour
{
    public bool startPointEvent;
    Animator anim_brownie;
    public static bool isHighfive;
    public GameObject sparkles;
    public GameObject hand;
    int state;
    //public bool isPointing;
    // Start is called before the first frame update
    void Start()
    {
        anim_brownie = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == (int)States.StartofGame)
        {
            StartCoroutine(WelcomeToGame());
            //play brownie's first line
        }
        if(startPointEvent)
        {
            StartCoroutine(StartPoint());
            
        }

        if(Highfive.isHighfive)
        {
            Instantiate(sparkles, (hand.transform));
            //insert YAY! sound effect for brownie
            //"Looks great!"
            anim_brownie.SetInteger("State", 3);
        }
    }

   IEnumerator WelcomeToGame()
    {
        //play welcome to the game sound clip
        yield return new WaitForSeconds(10F); //time to be decided when i record voice.. lol
        //play the clip that introduces the sketchbook
        yield return new WaitForSeconds(10f);
        //play the clip that tells the player to pick up the pallet with their other hand
        yield return new WaitForSeconds(5f);
        //play the clip that says the world is boring

    }

    IEnumerator StartPoint()
    {
        anim_brownie.SetInteger("State", 1);
        yield return new WaitForSeconds(1f);
        anim_brownie.SetInteger("State", 2);
        startPointEvent = false;
    }

}
public enum States
{
    StartofGame,
    StartPoint,
    MiddlePoint,
    EndPoint,

}
