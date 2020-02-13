using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Key Pressed");
            SaveButton();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Key Pressed");
            LoadButton();
        }
      
    }

    private Save createSaveObject()
    {
        Save save = new Save();

        save.something = SaveGameManager.instance.something;
        save.something_else = SaveGameManager.instance.something_else;

        return save;
    }

    public void SaveButton()
    {
        SaveJSON();
    }

    public void LoadButton()
    {
        LoadJSON();
    }

    public void SaveJSON()
    {
        Save save = createSaveObject();
        string Json_String = JsonUtility.ToJson(save);
        StreamWriter sw = new StreamWriter(Application.dataPath + "/JSONData.text");
        sw.Write(Json_String);
        sw.Close();

        Debug.Log("-=-=-=-SAVED-=-=-=-");
    }

    public void LoadJSON()
    {
        if (File.Exists(Application.dataPath + "/JSONData.text"))
        {
            //LOAD THE GAME
            StreamReader sr = new StreamReader(Application.dataPath + "/JSONData.text");

            string Json_String = sr.ReadToEnd();

            sr.Close();

            //Convert JSON to the Object(save)
            Save save = JsonUtility.FromJson<Save>(Json_String);//Into the Save Object

            Debug.Log("-=-=-=-LOADED-=-=-=-=-");

            //MARKER LOAD THE DATA TO THE GAME
            SaveGameManager.instance.something = save.something;
            SaveGameManager.instance.something_else = save.something_else;


        }

        else
        {
            Debug.Log("NOT FOUND FILE");
        }

    }   

}

