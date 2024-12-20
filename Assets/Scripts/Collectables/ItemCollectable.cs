using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;

public class ItemCollectable : CollectBase
{
    public SOInt value;
    public AudioSource sound;

    protected override void OnCollected()
    {

        if (CoinsManager.Instance != null)
        {
            if (sound != null) AudioManager.Instance.SFXPlayByType(SFXType.TYPE_COIN, sound);
            CoinsManager.Instance.AddByTyoe(ItemType.COIN);
            //sound.Play();
        }
        else
        {
            Debug.LogWarning("CoinsManager.Instance está nulo em ItemCollectable.OnCollected()");
        }

        base.OnCollected(); // Chama a implementação da classe base


    }
}