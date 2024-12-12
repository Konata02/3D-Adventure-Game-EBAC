using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ClothItemSpeed : ClothItemBase
{

    public Player playerSpeed;
    private float defaultSpeed;
    public float speedUp;


    public override void Collect()
    {
        base.Collect();
        ChangeSpeed();
    }

    public void ChangeSpeed()
    {
        StartCoroutine(ChangeSpeedCoroutine(speedUp, duration));
    }

    IEnumerator ChangeSpeedCoroutine(float speed, float duration)
    {
        defaultSpeed = playerSpeed.speed;
        playerSpeed.speed = speed;
        yield return new WaitForSeconds (duration);
        playerSpeed.speed = defaultSpeed;
        materialChanger.ChangeMaterials(materialChanger.materialsToChange[0]);


    } 

}

