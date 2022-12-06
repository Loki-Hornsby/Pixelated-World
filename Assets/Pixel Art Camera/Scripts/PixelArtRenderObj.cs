/// <summary>
/// Copyright 2022, Loki Alexander Button Hornsby (Loki Hornsby), All rights reserved.
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets up the object
/// This handles the object which displace the render texture
/// </summary>

[RequireComponent(typeof(MeshRenderer))]
public class PixelArtRenderObj : MonoBehaviour{
    public Material BaseMat;
    MeshRenderer MeshRend;

    public void SetTex(RenderTexture rend){
        // Apply the render texture to the base material
        BaseMat.mainTexture = rend;

        // Apply the material to this object
        MeshRend.materials = new Material[1] { BaseMat };
    }

    void Start(){
        // Setup
        MeshRend = GetComponent<MeshRenderer>();
        this.transform.localScale = new Vector3(2f, 2f, 1f);
    }
}
