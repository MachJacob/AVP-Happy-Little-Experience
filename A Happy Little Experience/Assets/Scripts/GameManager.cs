using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HDAdditionalLightData pointLight;
    [SerializeField] private HDAdditionalLightData worldLight;
    [SerializeField] private Camera[] cam;
    [SerializeField] private Grabbable brush;
    public static bool gameStart;
    public Transform brownieSpawn;
    private float fade;
    private float intensity;
    public static bool isTips;
    public AudioSource audioSource;
    public GameObject brownie;

    
    [SerializeField] private readonly float fadeTime = 5;

    void Awake()
    {
        cam[0].backgroundColor = Color.black;
        cam[1].backgroundColor = Color.black;
        cam[2].backgroundColor = Color.black;
        intensity = 0.0f;
        gameStart = false;
        fade = 0;
    }

    public void setTips()
    {
        isTips = !isTips;
    }

    void Update()
    {
        worldLight.intensity = intensity;
        pointLight.intensity = 1 - intensity;
        if (brush.held && !gameStart)
        {
            gameStart = true;
            audioSource.Play();
            Instantiate(brownie, brownieSpawn);
            fade = fadeTime;

            //Destroy(pointLight, 5.1f);
        }
        if (fade > 0)
        {
            float colR = Mathf.Lerp(0, 49 / 255f, 1 - fade / fadeTime);
            float colG = Mathf.Lerp(0, 77 / 255f, 1 - fade / fadeTime);
            float colB = Mathf.Lerp(0, 121 / 255f, 1 - fade / fadeTime);
            cam[0].backgroundColor = new Color(colR, colG, colB, 0 / 255f);
            cam[1].backgroundColor = new Color(colR, colG, colB, 5 / 255f);
            cam[2].backgroundColor = new Color(colR, colG, colB, 0 / 255f);
            intensity = Mathf.Lerp(0, 1, 1 - fade / fadeTime);
            fade -= Time.deltaTime;
        }
    }
}
