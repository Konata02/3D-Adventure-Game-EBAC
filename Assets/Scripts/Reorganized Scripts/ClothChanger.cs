using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothChanger : MonoBehaviour
{
    public SkinnedMeshRenderer mesh;
    public Texture2D texture;
    public string shaderIdName = "_EmissionMap";

    private void ChangeTexture()
    {
        mesh.sharedMaterials[0].SetTexture(shaderIdName, texture);
    }

}