using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Singleton;
using TMPro;
using Unity.VisualScripting;



namespace Itens
{
    public enum ItemType
    {
        COIN,
        LIFE_PACK
    }


public class CoinsManager : Ebac.Singleton.Singleton<CoinsManager>
{
    public SOInt coins;
    public SOInt lifepack;
    //public TextMeshProUGUI uiTextCoins;
    public List<ItemSetup> itemSetups;
    //public TextMeshProUGUI textCoinsCounter;



    protected override void Awake(){
        base.Awake();
        Reset();
        
    }
    
    private void Reset()
        {
            coins.value = 0;
            lifepack.value = 0;
            foreach(var i in itemSetups)
            {
                i.soInt.value = 0;
            }
            UpdateUI();
        }

    public void AddCoins(int amount = 1)
        {
            coins.value += amount;
            UpdateUI();
        }

    private void UpdateUI ()
        {
            //uiTextCoins.text = coins.ToString();
            
        }

     public ItemSetup GetByTyoe(ItemType itemType)
    {
        return itemSetups.Find( i => i.itemType == itemType);
    }
    public void AddByTyoe(ItemType itemType, int amount = 1)
    {
        itemSetups.Find( i => i.itemType == itemType).soInt.value += amount;
    }

    public void RemoveByType(ItemType itemType, int amount = 1)
    {
         itemSetups.Find( i => i.itemType == itemType).soInt.value -= amount;
    }
    
    /*private void UpdateCoinsUI()
    {
        
        if (textCoinsCounter != null)
        {
            
            textCoinsCounter.text = "X" + " " +  coins.ToString();
            
            
        }
        else
        {
            Debug.LogWarning("Text Coins Counter não atribuído em CoinsManager.");
        }
    }*/

}

    [System.Serializable]
    public class ItemSetup
    {
        public ItemType itemType;
        public SOInt soInt;
        public Sprite icon;
    }

}