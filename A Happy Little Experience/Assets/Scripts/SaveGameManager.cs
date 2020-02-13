using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SaveGameManager instance;

    public int something;
    public int something_else;
    public GameObject g_object;

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
