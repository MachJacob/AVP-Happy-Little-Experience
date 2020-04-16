using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AT_SaveManager : MonoBehaviour
{
    private static AT_SaveManager instance;

    AT_Saveable_Objects saveable_objects;
    AT_Spesific_Objects spesific_objects;
    public List<AT_Saveable_Objects> the_saveable_objects { get; set; }

    public static AT_SaveManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<AT_SaveManager>();
            }

            return instance;
        }

    } 

    void Awake()
    {
        the_saveable_objects = new List<AT_Saveable_Objects>();
        saveable_objects = FindObjectOfType<AT_Saveable_Objects>();
        spesific_objects = FindObjectOfType<AT_Spesific_Objects>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Debug.Log("Key Pressed");
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Key Pressed");
            Load();
        }
    }

    public AT_Save CreateSaveObject()
    {
        AT_Save save = new AT_Save();

        //Spesific_Objects spesific_obj = new Spesific_Objects();
        //save.init(id, position, rotation, scale);
        //saveable_objects.Save(id);

        //PlayerPrefs.SetInt("ObjectCount", the_saveable_objects.Count);
        for (int i = 0; i < the_saveable_objects.Count; i++)
        {

            //save.id = the_saveable_objects[i].id = 1;
            //save.position = saveable_objects.position + transform.position;
            //save.scale = saveable_objects.scale + transform.localScale;
            //save.rotation = saveable_objects.rotation = transform.localRotation;

            //the_saveable_objects[i].Save(save.id, save.position, save.rotation, save.scale);


            //the_saveable_objects[i].position + transform.position;
            //the_saveable_objects.scale[] + transform.localScale;
            //the_saveable_objects.rotation = transform.localRotation;

        }

        
        save.id = saveable_objects.id;
        save.position = saveable_objects.position;
        save.rotation = saveable_objects.rotation;
        save.scale = saveable_objects.scale;
        
       

        //Debug.Log("id:" + the_saveable_objects.Count);
        return save;
    }

    public void Save()
    {
        //* PlayerPref Way *\\
        //PlayerPrefs.SetInt("ObjectCount", the_saveable_objects.Count);
        //for (int i = 0; i < the_saveable_objects.Count; i++)
        //{
        //    the_saveable_objects[i].Save(i);

        //    the_saveable_objects[i].Save(id, position, rotation, scale);
        //}


        //* JSON Way *\\
        AT_Save save = CreateSaveObject();
        string Json_String = JsonUtility.ToJson(save);
        StreamWriter sw = new StreamWriter(Application.dataPath + "/JSONData.text");
        sw.Write(Json_String);
        sw.Close();
        Debug.Log("-=-=-=-SAVED-=-=-=-");
    }

    public void Load()
    {

        if (File.Exists(Application.dataPath + "/JSONData.text"))
        {
            //LOAD THE GAME
            StreamReader sr = new StreamReader(Application.dataPath + "/JSONData.text");

            string Json_String = sr.ReadToEnd();

            sr.Close();

            //Convert JSON to the Object(save)
            AT_Save save = JsonUtility.FromJson<AT_Save>(Json_String);//Into the Save Object

            Debug.Log("-=-=-=-LOADED-=-=-=-=-");

            int object_limit = saveable_objects.id;
            saveable_objects.id = save.id;
            saveable_objects.transform.position = new Vector3(save.position.x, save.position.y, save.position.z);
            saveable_objects.transform.localScale = new Vector3(save.scale.x, save.scale.y, save.scale.z);

            for (int i = 0; i < object_limit ; i++)
            {

            }

        }
        else
        {
            Debug.Log("NOT FOUND FILE");
        }
    }

    public Vector3 StringToVector(string value)
    {
        //(1, 23, 3)//
        value = value.Trim(new char[] { '(', ')' });

        //1, 23, 3//
        value = value.Replace(" ", "");

        //1,23,3//
        string[] pos = value.Split(',');

        //[0] = 1 [1] = 2 [2] = 3//
        return new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2]));
    }

    public Quaternion StringToQuaternion(string value)
    {
        //(1, 23, 3)//
        value = value.Trim(new char[] { '(', ')' });

        //1, 23, 3//
        value = value.Replace(" ", "");

        //1,23,3//
        string[] pos = value.Split(',');

        //[0] = 1 [1] = 2 [2] = 3//
        return new Quaternion(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2]), float.Parse(pos[3]));
    }
}
