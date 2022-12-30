/// <summary>
/// Copyright 2022, Loki Alexander Button Hornsby (Loki Hornsby), All rights reserved.
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets up the child camera
/// This handles creation of and output to the render texture
/// </summary>

namespace Pixel {
    [RequireComponent(typeof(Camera))]
    public class PixelArtCameraChild : MonoBehaviour{
        [System.NonSerialized] public Camera camera;

        [Header("References")]
        public PixelArtCamera pixelcam;

        public PixelArtRenderObj RenderObject;
        RenderTexture rt;

        [Header("Configuration")]
        [Range(2, TexResCap)] public int TexRes;
        
        // Defined Settings
        public const int TexResCap = 2048;
        public const int depth = 32;
        public const RenderTextureFormat format = RenderTextureFormat.ARGB32;

        /// <summary>
        /// Create render texture
        /// </summary>
        public void CreateRenderTexture(){
            // Create Render Texture
            rt = new RenderTexture(
                64, 
                64, 
                depth, 
                format
            );

            rt.filterMode = FilterMode.Point;
            rt.Create();

            // Set Render Texture
            RenderObject.SetTex(rt);
            camera.targetTexture = rt;
        }

        /// <summary>
        /// Setup
        /// </summary>
        void Start(){
            // Camera setup
            camera = GetComponent<Camera>();
            camera.orthographic = false;
            camera.allowHDR = false;
            camera.allowMSAA = false;

            // Position setup
            this.transform.position = new Vector3(0f, 0f, 0f);

            // Create the render texture
            CreateRenderTexture();
        }

        /// <summary>
        /// Resize render texture
        /// </summary>
        void Resize(Vector2Int res) {
            rt.Release();
            rt.width = (res.x > 0) ? res.x : 1;
            rt.height = (res.y > 0) ? res.y : 1; 
        }

        /// <summary>
        /// Get texture resolution
        /// </summary>
        Vector2Int GetTextureResolution(){
            Vector2Int res = (TexRes > TexResCap || TexRes < 2) ? 
                new Vector2Int(TexResCap, TexResCap) : new Vector2Int(TexRes, TexRes);

            return res;
        }

        /// <summary>
        /// Update camera
        /// </summary>
        void Update(){
            // Texture Resolution
            Vector2Int res = GetTextureResolution();
            if (rt.width != res.x || rt.height != res.y) Resize(res);
        }
    }
}