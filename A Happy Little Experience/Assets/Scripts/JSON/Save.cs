using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public int something;
    public int something_else;

    public int id;
    public Vector3 g_positions;
    public float g_poisions_x;
    public float g_poisions_y;
    public GameObject g_object;



    //test stuff
    public int coinsNum;
    public int diamondsNum;

    public float playerPositionX;
    public float playerPositionY;

    //MARKER If you want to save the enemy position 
    public List<float> enemyPositionX = new List<float>();
    public List<float> enemyPositionY = new List<float>();
    public List<bool> isDead = new List<bool>();

    public List<float> g_object_pos = new List<float>();


}

public class SavePos
{

    public List<float> g_object_pos = new List<float>();

}


