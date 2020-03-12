using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SaveGameManager instance;

    public int something;
    public int something_else;

    public int id;
    public Vector3 g_positions;
    public GameObject g_object;


    public bool isPaused;//When the variabel is false, the game continue

    public int coins, diamonds;//WE can use GameManager.instance.coin to get access from other script
    public Text coinText, diamondText;

    //MARKER ALL ENEMIES IN THIS GAME
    //public List<Bat> bats = new List<Bat>();

    public List<SavePos> savePos = new List<SavePos>();


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);

            }
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        GameObject DEAD = null;

        Destroyy(DEAD);
    }

    public void Destroyy(GameObject ded)
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("DIE!!!!!!!!!!!!!!!!");
            Destroy(g_object);
            g_object = null;
        }
    }
}
