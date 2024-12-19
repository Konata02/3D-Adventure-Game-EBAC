using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothItemForce : ClothItemBase
{


    //private int  defaultDamage;

    public SOInt bulletsdamage;


    public override void Collect()
    {
        base.Collect();
        ChangeForce();
    }

    public void ChangeForce()
    {
        clothSetup.ChangePlayerDamageBullets(bulletsdamage);
        //defaultDamage = bulletsdamage.value;
        //StartCoroutine(ChangeForceCoroutine(speedJumpUp, duration));
    }

    /*IEnumerator ChangeForceCoroutine(float speed, float duration)
    {
        defaultJumpSpeed = playerForce.jumpSpeed;
        defaultDamage = bulletsdamage.value;
        playerForce.jumpSpeed = speed;
        bulletsdamage.value = damageUp;
        yield return new WaitForSeconds (duration);
        playerForce.jumpSpeed = defaultJumpSpeed;
        bulletsdamage.value = defaultDamage;
        materialChanger.ChangeMaterials(materialChanger.materialsToChange[0]);


    } */

}
