using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : EnemyBase
{
    public GunBase gunBase;


    private void Update()
    {
        gunBase.StartShoot();
        
    }

   
}
