using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PixelArtCamera : MonoBehaviour {
    public static PixelArtCamera Instance;

    // General Setup
    Camera camera;
    public RenderTexture PixelArtRendText;

    void Awake(){
        if (Instance != null){
            Instance = this;
        } else {
            Debug.LogError("Instance of camera already exists");

            Destroy(this);
        }
    }

    void Start(){
        camera.GetComponent<Camera>();

        camera.targetTexture = PixelArtRendText;
    }
}
