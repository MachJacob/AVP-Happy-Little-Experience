﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AT_Save
{
    public string name;
    public int id;


    public Transform the_transform;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    public Color colour;
    public Material material;


    public void init(string _name, int _id, Transform _transform, Vector3 _position, Quaternion _rotation, Vector3 _scale, Color _colour, Material _material)
    {
        name = _name;
        id = _id;
        the_transform = _transform;
        position = _position;
        rotation = _rotation;
        scale = _scale;
        colour = _colour;
        material = _material;
    }

}