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
    public static int state;
    //public bool isPointing;
    // Start is called before the first frame update
    void Start()
    {
        anim_brownie = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == (int)GameStates.Tutorial)
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
            anim_brownie.SetInteger("State", (int)BrownieStates.EndPoint);
        }
    }

   IEnumerator WelcomeToGame()
    {
        //play welcome to the game sound clip
        Debug.Log("Hey there! Welcome to your Happy Little Experience! I'm Brownie, nice to meet ya!");
        yield return new WaitForSeconds(10F); //time to be decided when i record voice.. lol
        //play the clip that introduces the sketchbook
        yield return new WaitForSeconds(10f);
        //play the clip that tells the player to pick up the pallet with their other hand
        yield return new WaitForSeconds(5f);
        //play the clip that says the world is boring

    }

    IEnumerator StartPoint()
    {
        anim_brownie.SetInteger("State", (int)BrownieStates.StartPoint);
        yield return new WaitForSeconds(1f);
        anim_brownie.SetInteger("State", (int)BrownieStates.MiddlePoint);
        startPointEvent = false;
    }

}
public enum GameStates
{
    Tutorial,
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
