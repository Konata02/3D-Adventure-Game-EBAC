using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SingleShotGun : GunBase
{

    protected override IEnumerator ShootCoroutine()
    {
        // Dispara uma vez
        Shoot();
        yield return new WaitForSeconds(timeBetweenShoot);
        
        // Reseta a corrotina para permitir um novo disparo
        _currentCoroutine = null; 
    }

}

