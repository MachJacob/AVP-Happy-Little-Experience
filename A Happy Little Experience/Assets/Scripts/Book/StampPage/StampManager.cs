using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampManager : MonoBehaviour
{
    public GameObject stamePagePrefab;

    List<GameObject> stampPages = new List<GameObject>();
    int currentPage;

    List<Sprite> textures = new List<Sprite>();
    List<Mesh> meshes = new List<Mesh>();
    int createdStamps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        while (createdStamps > textures.Count)
        {
            if(createdStamps % 6 == 0)
            {

            }

            createdStamps++;
        }
    }
}
