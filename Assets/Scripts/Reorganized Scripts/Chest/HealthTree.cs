using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthTree : HealthBase
{
    public float shakeDuration = .1f;
    public int shakeForce = 1;
    public GameObject coinPrefab;
    public int coinAmount = 10;
    public Transform dropPosition;

    public override void Damage(int damage)
    {
        base.Damage(damage);
        transform.DOShakeScale(shakeDuration, Vector3.up, shakeForce);
        DropCoin();
    }

    private void DropCoin()
    {
        if (coinAmount > 0)
        {
            var i = Instantiate(coinPrefab);
            i.transform.position = dropPosition.position;
            coinAmount--;
        }

    }

}
