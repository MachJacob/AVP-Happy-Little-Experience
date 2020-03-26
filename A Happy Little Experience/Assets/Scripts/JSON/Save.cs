using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public string name;
    public int id;

    public Transform the_transform;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;


    public float playerPositionX;
    public float playerPositionY;


    public void init(int _id, Transform _transform, Vector3 _position, Quaternion _rotation, Vector3 _scale)
    {
        id = _id;
        the_transform = _transform;
        position = _position;
        rotation = _rotation;
        scale = _scale;

    }
}
