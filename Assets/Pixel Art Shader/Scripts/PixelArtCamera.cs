using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets up the main camera
/// This handles the game view - which faces the render texture
/// </summary>

[RequireComponent(typeof(Camera))]
public class PixelArtCamera : MonoBehaviour {
    // General Setup
    new Camera camera;
    public PixelArtCameraChild child;
    public float OffsetDist;

    // Constants
    public const int Res = 128;
    public const int TexRes = 4096;
    public const int Depth = 32;
    public const RenderTextureFormat RTF = RenderTextureFormat.ARGB32;
    public const int OrthSize = 1;

    void Start(){
        // Camera setup
        camera = GetComponent<Camera>();
        camera.orthographic = true;
        camera.orthographicSize = OrthSize;
        
        // Position setup
        this.transform.position = new Vector3(0f, -Mathf.Abs(OffsetDist), 0f);
        child.transform.position = new Vector3(0f, 0f, 0f);

        // Set Screen Res
        Screen.SetResolution(Res, Res, false);

        // Create render texture using child
        child.ApplyNewRenderTexture(TexRes, TexRes, Depth, RTF);
    }
}
