using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotHandler : MonoBehaviour
{
    private static ScreenShotHandler instance;

    private Camera myCamera;
    private bool takeScreenShotOnNextFrame;
    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
        
    }

    private void OnPostRender()
    {
        if(takeScreenShotOnNextFrame)
        {
            takeScreenShotOnNextFrame = false;
            RenderTexture render_texture = myCamera.targetTexture;


            Texture2D render_Result = new Texture2D(render_texture.width, render_texture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, render_texture.width, render_texture.height);
            //render_Result;
        }
    }

    private void TakeScreenShot(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenShotOnNextFrame = true;
    }
}
