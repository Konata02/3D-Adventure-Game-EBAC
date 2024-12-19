using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothItemBase : MonoBehaviour
{
    public ClothType clothType;
    public ClothChangerV2 materialChanger;
    public float duration;
    private float durationPlus;
    protected ClothSetup clothSetup;
    public string compareTag = "Player";

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(compareTag))
        {
            Collect();
        }
    }

    public virtual void Collect()
    {
        clothSetup = ClothManager.Instance.GetSetupByType(clothType);
        ClothManager.Instance._currentEquippedCloth = clothSetup.id;
        materialChanger.ChangeMaterials(clothSetup.material);
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
