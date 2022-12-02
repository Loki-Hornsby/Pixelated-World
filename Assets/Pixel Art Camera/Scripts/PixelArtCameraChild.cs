using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets up the child camera
/// This handles creation of and output to the render texture
/// </summary>

[RequireComponent(typeof(Camera))]
public class PixelArtCameraChild : MonoBehaviour{
    [System.NonSerialized] public new Camera camera;
    public PixelArtRenderObj RenderObject;

    public const int depth = 32;
    public const RenderTextureFormat format = RenderTextureFormat.ARGB32;

    public void ApplyNewRenderTexture(int v){
        // Create
        RenderTexture rt = new RenderTexture(v, v, depth, format);
        rt.filterMode = FilterMode.Point;
        rt.Create();

        // Apply
        RenderObject.SetTex(rt);
        camera.targetTexture = rt;
    }

    void Start(){
        // Setup Camera
        camera = GetComponent<Camera>();
        camera.allowHDR = false;
        camera.allowMSAA = false;
    }
}
