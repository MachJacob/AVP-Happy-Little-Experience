using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ObjectTypes
{
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
    [SerializeField] public GameObject the_transform;
    [SerializeField] public Vector3 position;
    [SerializeField] public Quaternion rotation;
    [SerializeField] public Vector3 scale;

    void Start()
    {
        AT_SaveManager.Instance.the_saveable_objects.Add(this);
    }

    void Update()
    {
       
    }

    public virtual void Save(string _name, int _id , Vector3 _position, Quaternion _rotation, Vector3 _scale)
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
    }

    public virtual void Load(string[] values, int _id, Vector3 _position, Quaternion _rotation, Vector3 _scale)
    {

    }

    public void DestroySavable()
    {
        AT_SaveManager.Instance.the_saveable_objects.Remove(this);
        Destroy(gameObject);
    }

}
