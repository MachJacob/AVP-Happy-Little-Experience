using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AT_Save
{
    public string name;
    public int id;

    public GameObject current_object;
    public GameObject new_object;

    public Transform the_transform;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    public Color colour;
    public Color pen_colour;
    public Color32[] cur_colors;


    public Material material;
    public Material new_material;
    public Sprite drawable_sprite;
    public Texture2D drawable_texture2D;

    public LayerMask Drawing_Layers;

    public void init(string _name, int _id, GameObject _current_object, GameObject _new_object, Transform _transform, Vector3 _position, 
        Quaternion _rotation, Vector3 _scale, Color _colour, Color _pen_colour, Color32[] _cur_colours ,Material _material, Material _new_material,
        Sprite _drawable_sprite, Texture2D _drawable_texture2D, LayerMask _drawing_layers)
    {
        name = _name;
        id = _id;
        current_object = _current_object;
        new_object = _new_object;
        the_transform = _transform;
        position = _position;
        rotation = _rotation;
        scale = _scale;
        colour = _colour;
        pen_colour = _pen_colour;
        cur_colors = _cur_colours;
        material = _material;
        new_material = _new_material;
        drawable_sprite = _drawable_sprite;
        drawable_texture2D = _drawable_texture2D;
        Drawing_Layers = _drawing_layers;

    }

}