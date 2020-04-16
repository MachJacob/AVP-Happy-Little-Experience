using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_Spesific_Objects : AT_Saveable_Objects
{
    // Start is called before the first frame update

    //[SerializeField] public GameObject cube;

    //[SerializeField] public GameObject the_position; 


    void Update()
    {
        position = gameObject.transform.position;
    }

    public override void Save(string _name, int _id, Vector3 _position, Quaternion _rotation,
        Vector3 _scale, Color _colour, Color32[] _cur_colours, Material _material,
        Sprite _drawable_sprite, Texture2D _drawable_texture2D, LayerMask _drawing_layers)
    {
        position = _position;
        material[1] = _material;
        //_position = this.the_position.transform.localPosition;
        base.Save(_name, _id, _position, _rotation, _scale, _colour, _cur_colours, _material, _drawable_sprite, _drawable_texture2D, _drawing_layers);
    }

    public override void Load(string[] values, int _id, Vector3 _position, Quaternion _rotation, Vector3 _scale)
    {
        base.Load(values, _id, _position, _rotation, _scale);
    }
}

