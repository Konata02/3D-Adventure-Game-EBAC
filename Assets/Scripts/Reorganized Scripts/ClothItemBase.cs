using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothItemBase : MonoBehaviour
{
    public ClothType clothType;
    public ClothChangerV2 materialChanger;
    public float duration;
    private float durationPlus;


    public string compareTag = "Player";
        private void OnTriggerEnter(Collider collision)
    {
        Collect();
    }

    public virtual void Collect()
    {   
        var setup = ClothManager.Instance.GetSetupByType(clothType);
        materialChanger.ChangeMaterials(setup.material);
        durationPlus = duration + 0.5f;
        HideObject();
    }

    private void HideObject()
    {
        GetComponent<Renderer>().enabled = false;
        Invoke("DeactivateGameObject", durationPlus);

        
    }

    void DeactivateGameObject()
    {
        Destroy(gameObject);
    }



}
