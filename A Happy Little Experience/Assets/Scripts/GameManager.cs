using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Light pointLight;
    [SerializeField] private Light worldLight;
    [SerializeField] private Camera[] cam;
    [SerializeField] private Grabbable brush;
    [SerializeField] private bool gameStart;

    void Start()
    {
        cam[0].backgroundColor = Color.black;
        cam[1].backgroundColor = Color.black;
        cam[2].backgroundColor = Color.black;
        gameStart = false;
    }

    void Update()
    {
        if (brush.held)
        {
            gameStart = true;
        }
        if (gameStart) 
        {
            cam[0].backgroundColor = new Color(49 / 255f, 77 / 255f, 121 / 255f, 0 / 255f);
            cam[1].backgroundColor = new Color(49 / 255f, 77 / 255f, 121 / 255f, 5 / 255f);
            cam[2].backgroundColor = new Color(49 / 255f, 77 / 255f, 121 / 255f, 0 / 255f);

            Destroy(pointLight);
            worldLight.intensity = 1;
            gameStart = false;
        }
    }
}
