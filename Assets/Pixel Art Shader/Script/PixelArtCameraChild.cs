using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets up the child camera
/// This handles creation of and output to the render texture
/// </summary>

[RequireComponent(typeof(Camera))]
public class PixelArtCameraChild : MonoBehaviour{
    new Camera camera;
    public PixelArtRenderObj RenderObject;

    public void ApplyNewRenderTexture(int x, int y, int z, RenderTextureFormat q){
        // Create
        RenderTexture rt = new RenderTexture(x, y, z, q);
        rt.Create();

        // Apply
        RenderObject.SetTex(rt);
        camera.targetTexture = rt;
    }

    void Start(){
        // Setup Camera
        camera = GetComponent<Camera>();
    }
}
