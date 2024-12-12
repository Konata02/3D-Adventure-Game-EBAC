using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothChangerV2 : MonoBehaviour
{
    // Lista de SkinnedMeshRenderers que terão seus materiais trocados
    public List<SkinnedMeshRenderer> skinnedMeshRenderers;

    // Lista de materiais que serão aplicados nos SkinnedMeshRenderers
    public List<Material> materialsToChange;

    // Método para trocar os materiais de todos os SkinnedMeshRenderers
    public void ChangeMaterials(Material material)
    {
        for (int i = 0; i < skinnedMeshRenderers.Count; i++)
        {
            // Garantir que o índice do material não exceda a lista de materiais
            if (i < materialsToChange.Count)
            {
                ChangeMaterial(skinnedMeshRenderers[i], material);
            }
        }
    }

    // Método específico para trocar o material de um SkinnedMeshRenderer
    private void ChangeMaterial(SkinnedMeshRenderer skinnedMeshRenderer, Material newMaterial)
    {
        // Aqui você pode alterar qualquer material, por exemplo, trocando o material principal (index 0)
        if (skinnedMeshRenderer != null)
        {
            Material[] currentMaterials = skinnedMeshRenderer.sharedMaterials;

            // Substituir o material principal por um novo
            currentMaterials[0] = newMaterial;

            // Aplicar os novos materiais no SkinnedMeshRenderer
            skinnedMeshRenderer.sharedMaterials = currentMaterials;
        }
    }
}