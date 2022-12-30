/// <summary>
/// Copyright 2022, Loki Alexander Button Hornsby (Loki Hornsby), All rights reserved.
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets up the main camera
/// This handles the game view - which faces the render texture
/// </summary>

namespace Pixel {
    [RequireComponent(typeof(Camera))]
    public class PixelArtCamera : MonoBehaviour {
        [System.NonSerialized] public Camera camera;

        [Header("References")]
        public PixelArtCameraChild child;
        
        [Header("Configuration")]
        public float offset;

        /// <summary>
        /// Get the size of the camera in unity
        /// </summary>
        public Vector2 GetRealSize(){
            float height = 2f * camera.orthographicSize;
            float width = height * camera.aspect;

            return new Vector2(width, height);
        }

        /// <summary>
        /// Setup the pixel camera
        /// /// </summary>
        void Awake(){
            // Camera setup
            camera = GetComponent<Camera>();
            camera.orthographic = true;
            camera.orthographicSize = 0.5f;
            camera.allowHDR = false;
            camera.allowMSAA = false;
            
            // Position setup
            this.transform.position = new Vector3(0f, -offset, 0f);
        }
    }
}