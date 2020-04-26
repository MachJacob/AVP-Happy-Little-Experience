using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ObjectTypes
{
    Cube,
    Tree,
    Cloud,
    Grass,
    What_else
}

public abstract class AT_Saveable_Objects : MonoBehaviour
{
    [SerializeField] private ObjectTypes objectType;
    [SerializeField] public string name;
    [SerializeField] public int id;
    [SerializeField] public GameObject current_object;
    [SerializeField] public Vector3 position;
    [SerializeField] public Quaternion rotation;
    [SerializeField] public Vector3 scale;
    [SerializeField] public Color colour;
    [SerializeField] public Color32[] cur_colors;
    [SerializeField] public Material material;
    [SerializeField] public Sprite drawable_sprite;
    [SerializeField] public Texture2D drawable_texture2D;
    //[SerializeField] public LayerMask Drawing_Layers;

    [SerializeField] public Material new_mat;


    protected Renderer rend;

    void Start()
    {
        AT_SaveManager.Instance.the_saveable_objects.Add(this);
    }

    void Update()
    {
       
    }

    public virtual void Save(string _name, int _id, GameObject _current_object, Vector3 _position, Quaternion _rotation, Vector3 _scale, 
        Color _colour, Color32[] _cur_colours, Material _material,
        Sprite _drawable_sprite, Texture2D _drawable_texture2D, LayerMask _drawing_layers)
    {

        name = _name;

        id = _id;
        id.ToString();

        position = _position;
        //position = transform.position; 
        position.ToString();

        rotation = _rotation;
        //rotation = transform.localRotation;
        rotation.ToString();

        scale = _scale;
        scale.ToString();

        colour = _colour;
        colour.ToString();

        cur_colors = _cur_colours;
        cur_colors.ToString();

        material = _material;
        material.ToString();

        drawable_sprite = _drawable_sprite;

        drawable_texture2D = _drawable_texture2D;

        //Drawing_Layers = _drawing_layers;

    }

    public virtual void Load(string[] values, int _id, Vector3 _position, Quaternion _rotation, Vector3 _scale)
    {

    }

    public void DestroySavable()
    {
        AT_SaveManager.Instance.the_saveable_objects.Remove(this);
        Destroy(gameObject);
    }

    //private void ObjectString(this ObjectTypes objectType)
    //{
    //    objectType.ToString();
    //}

}
