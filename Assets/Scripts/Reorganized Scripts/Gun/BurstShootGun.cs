using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstShotGun : GunBase
{
    public float timeBetweenBurstShots = 0.1f;

    protected override IEnumerator ShootCoroutine()
    {
        for (int i = 0; i < shootsPerClick; i++)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenBurstShots);
        }
        yield return new WaitForSeconds(timeBetweenShoot);

         _currentCoroutine = null; 
    }
}