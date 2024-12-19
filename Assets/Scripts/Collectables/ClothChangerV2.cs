using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Singleton;

public class ClothChangerV2 : Singleton<ClothChangerV2>
{

    public List<SkinnedMeshRenderer> skinnedMeshRenderers;


    public List<Material> materialsToChange;


    public void ChangeMaterials(Material material)
    {
        for (int i = 0; i < skinnedMeshRenderers.Count; i++)
        {

            if (i < materialsToChange.Count)
            {
                ChangeMaterial(skinnedMeshRenderers[i], material);
            }
        }
    }


    private void ChangeMaterial(SkinnedMeshRenderer skinnedMeshRenderer, Material newMaterial)
    {

        if (skinnedMeshRenderer != null)
        {
            Material[] currentMaterials = skinnedMeshRenderer.sharedMaterials;


            currentMaterials[0] = newMaterial;


            skinnedMeshRenderer.sharedMaterials = currentMaterials;
        }
    }
}