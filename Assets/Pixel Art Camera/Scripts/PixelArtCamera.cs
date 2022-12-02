using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets up the main camera
/// This handles the game view - which faces the render texture
/// </summary>

[RequireComponent(typeof(Camera))]
public class PixelArtCamera : MonoBehaviour {
    // Resolution
    [Header("Resolution")]
    public int TargetRes; 
    int CurrentRes;

    public int TargetTexRes;
    int CurrentTexRes;

    public const int cap = 2048;

    // Camera
    [Header("Camera")]
    [Range(0, 60)]
    public float zoom;
    public float offset;
    public PixelArtCameraChild child;
    public const int OrthSize = 1;
    new Camera camera;

    void Start(){
        // Camera setup
        camera = GetComponent<Camera>();
        camera.orthographic = true;
        camera.orthographicSize = OrthSize;
        camera.allowHDR = false;
        camera.allowMSAA = false;
        
        // Position setup
        this.transform.position = new Vector3(0f, -Mathf.Abs(offset), 0f);
        child.transform.position = new Vector3(0f, 0f, 0f);
    }

    void Update(){
        // Apply Zoom
        if (child.camera.fieldOfView != zoom) child.camera.fieldOfView = zoom;

        // Apply a new resolution
        if (TargetTexRes != CurrentTexRes){
            if (TargetTexRes % 2 != 0) Debug.LogError("Tex Res isn't a multiple of 2 and so therefore will scale incorrectly");

            child.ApplyNewRenderTexture(TargetTexRes);

            CurrentTexRes = TargetTexRes;
        }

        // Apply a new screen resolution
        if (TargetRes != CurrentRes){
            if (TargetRes % 2 != 0) Debug.LogError("Res isn't a multiple of 2 and so therefore will scale incorrectly");

            // Set Screen Res
            Screen.SetResolution(TargetRes, TargetRes, false);

            CurrentRes = TargetRes;
        }

        // Fatal Error
        if (TargetRes < TargetTexRes){
            Debug.LogError("Res shouldn't be lower than Target Texture Resolution");

            TargetRes = TargetTexRes;
        }

        if (TargetRes > cap){
            Debug.LogError("Res shouldn't be higher than 2048");

            TargetRes = cap;
        }

        if (TargetTexRes > cap){
            Debug.LogError("Text Res shouldn't be higher than 2048");

            TargetTexRes = cap;
        }
    }
}
