using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two) || Input.GetKeyDown(KeyCode.Return))
        {
            int count = SceneManager.sceneCountInBuildSettings;
            int index = SceneManager.GetActiveScene().buildIndex;

            if((index+1) >= count)
            { index = 0; }

            SceneManager.LoadScene(index + 1);
        }
    }
}
