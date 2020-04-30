using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public GameObject drawing_canvas;
    public Sprite[] sprites;
    int sprites_index = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            drawing_canvas.GetComponent<FreeDraw.Drawable>().ChangeTexture(sprites[sprites_index]);

            sprites_index = sprites_index < sprites.Length - 1 ? sprites_index + 1 : 0;

        }
    }
}
