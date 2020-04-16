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

    public override void Save(string _name, int _id, Vector3 _position, Quaternion _rotation, Vector3 _scale)
    {
        position = _position;
        //_position = this.the_position.transform.localPosition;
        base.Save(_name, _id, _position, _rotation, _scale);
    }

    public override void Load(string[] values, int _id, Vector3 _position, Quaternion _rotation, Vector3 _scale)
    {
        base.Load(values, _id, _position, _rotation, _scale);
    }
}

