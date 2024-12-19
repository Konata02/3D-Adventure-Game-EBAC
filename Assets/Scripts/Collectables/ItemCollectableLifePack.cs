using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;

public class ItemCollectableLifePack : CollectBase
{
    public SOInt value;

    protected override void OnCollected()
    {

        if (CoinsManager.Instance != null)
        {
            CoinsManager.Instance.AddByTyoe(ItemType.LIFE_PACK);
        }
        else
        {
            Debug.LogWarning("CoinsManager.Instance está nulo em ItemCollectable.OnCollected()");
        }

        base.OnCollected(); // Chama a implementação da classe base


    }
}
