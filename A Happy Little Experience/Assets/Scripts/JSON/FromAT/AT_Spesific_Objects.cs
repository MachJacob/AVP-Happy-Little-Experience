using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_Spesific_Objects : AT_Saveable_Objects
{
    // Start is called before the first frame update

    //[SerializeField] public GameObject cube;

    //[SerializeField] public GameObject the_position; 
     void Start()
    {
        //cur_colors = this.gameObject.GetComponent<Color32[]>();
        
    }

    void Update()
    {
        current_object = this.gameObject;

        position = gameObject.transform.position;
        rotation = gameObject.transform.rotation;
        scale = gameObject.transform.localScale;
        
        current_object.GetComponent<Renderer>().material = material;

        //current_object.GetComponent<SpriteRenderer>().sprite = drawable_sprite;

        //current_object.GetComponent<Renderer>().material.SetTexture("drawable_texture", drawable_texture2D);
        //current_object.GetComponent<Renderer>().material.mainTexture = drawable_texture2D;
    }

    public override void Save(string _name, int _id, GameObject _current_object, Vector3 _position, Quaternion _rotation,
        Vector3 _scale, Color _colour, Color32[] _cur_colours, Material _material,
        Sprite _drawable_sprite, Texture2D _drawable_texture2D, LayerMask _drawing_layers)
    {
        current_object.GetComponent<Renderer>().material = new_mat;
        position = _position;
        material = _material;
        colour = _colour;
        cur_colors = _cur_colours;
        drawable_sprite = _drawable_sprite;
        drawable_texture2D = _drawable_texture2D;

        //_position = this.the_position.transform.localPosition;
        base.Save(_name, _id, _current_object, _position, _rotation, _scale, _colour, _cur_colours, _material, _drawable_sprite, _drawable_texture2D, _drawing_layers);
    }

    public override void Load(string[] values, int _id, Vector3 _position, Quaternion _rotation, Vector3 _scale)
    {
        base.Load(values, _id, _position, _rotation, _scale);
    }
}

