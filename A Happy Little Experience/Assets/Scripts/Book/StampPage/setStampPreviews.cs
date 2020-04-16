using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setStampPreviews : MonoBehaviour
{
    public List<GameObject> slots;
    public List<Sprite> textures;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < textures.Count; i++)
        {
            slots[i].GetComponent<BoxCollider>().enabled = true;
            Instantiate(new SpriteRenderer(), slots[i].transform).sprite = textures[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
