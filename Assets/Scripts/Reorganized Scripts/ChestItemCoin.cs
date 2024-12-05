using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Itens;


public class ChestItemCoin : ChestItemBase
{
    public int counterCoin = 5 ;
    public GameObject coinObject;
    private List<GameObject> _itens = new List<GameObject>();
    public Vector2 radomRange = new Vector2(-2f,2f);
    public float tweenEndTime = .5f;

    public override void ShowItem()
    {
        base.ShowItem();
        CreateItens();

    }

    private void CreateItens()
    {
        for(int i = 0 ; i < counterCoin ; i++)
        {
            var item = Instantiate(coinObject);    
            item.transform.position = transform.position + Vector3.forward * Random.Range(radomRange.x,radomRange.y) + Vector3.right * Random.Range(radomRange.x,radomRange.y);
            item.transform.DOScale(0,.2f).SetEase(Ease.OutBack).From();
            _itens.Add(item);
            CoinsManager.Instance.AddByTyoe(ItemType.COIN);
        }
    }

    public override void Collect() 
    {
        base.Collect();

        foreach(var i in _itens)
            {
                i.transform.DOMoveY(2f, tweenEndTime).SetRelative();
                i.transform.DOScale(0, tweenEndTime/2).SetDelay(tweenEndTime/2);
            }
    }

}
