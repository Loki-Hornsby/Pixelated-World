/// <summary>
/// Copyright 2022, Loki Alexander Button Hornsby (Loki Hornsby), All rights reserved.
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets up the object
/// This handles the object which displays the render texture
/// </summary>

namespace Pixel {
    [RequireComponent(typeof(MeshRenderer))]
    public class PixelArtRenderObj : MonoBehaviour{
        [Header("References")]
        public Material BaseMat;
        MeshRenderer MeshRend;
        
        public PixelArtCamera pixelcam;

        /// <summary>
        /// Apply a render texture to the object
        /// </summary>
        public void SetTex(RenderTexture rend){
            // Apply the render texture to the base material
            BaseMat.mainTexture = rend;

            // Apply the material to this object
            MeshRend.materials = new Material[1] { BaseMat };
        }

        /// <summary>
        /// Setup the object
        /// </summary>
        void Start(){
            // Setup
            MeshRend = GetComponent<MeshRenderer>();

            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            this.transform.localPosition = new Vector3(0f, 0f, 1f);
        }

        /// <summary>
        /// Refresh the object
        /// </summary>
        void Refresh(float width, float height){
            float val = Mathf.Max(width, height);

            this.transform.localScale = new Vector3(
                val, 
                val, 
                this.transform.localScale.z
            );
        }

        /// <summary>
        /// Update the object
        /// </summary>
        void Update(){
            // Size update
            Vector2 size = pixelcam.GetRealSize();
            if (this.transform.localScale.x != size.x || this.transform.localScale.y != size.y) Refresh(size.x, size.y);
        }
    }
}