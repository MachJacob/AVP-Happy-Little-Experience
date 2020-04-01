using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Light pointLight;
    [SerializeField] private Light worldLight;
    [SerializeField] private Camera[] cam;
    [SerializeField] private Grabbable brush;
    private bool gameStart;
    private float fade;
    [SerializeField] private readonly float fadeTime = 5;

    void Start()
    {
        cam[0].backgroundColor = Color.black;
        cam[1].backgroundColor = Color.black;
        cam[2].backgroundColor = Color.black;
        gameStart = false;
    }

    void Update()
    {
        if (brush.held && !gameStart)
        {
            gameStart = true;
            fade = fadeTime;

            Destroy(pointLight, 5.1f);
        }
        if (fade > 0)
        {
            float colR = Mathf.Lerp(0, 49 / 255f, 1 - fade / fadeTime);
            float colG = Mathf.Lerp(0, 77 / 255f, 1 - fade / fadeTime);
            float colB = Mathf.Lerp(0, 121 / 255f, 1 - fade / fadeTime);
            cam[0].backgroundColor = new Color(colR, colG, colB, 0 / 255f);
            cam[1].backgroundColor = new Color(colR, colG, colB, 5 / 255f);
            cam[2].backgroundColor = new Color(colR, colG, colB, 0 / 255f);
            worldLight.intensity = Mathf.Lerp(0, 1, 1 - fade / fadeTime);
            pointLight.intensity = Mathf.Lerp(0, 1, fade / fadeTime);
            fade -= Time.deltaTime;
        }
    }
}
