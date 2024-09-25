using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public abstract class GunBase : MonoBehaviour
{
    public PoolManager poolManager;
    public Transform positionToShoot;
    public float timeBetweenShoot;
    public int shootsPerClick;

    protected Coroutine _currentCoroutine;

    public virtual void StartShoot()
    {
        if (_currentCoroutine == null)
        {
            _currentCoroutine = StartCoroutine(ShootCoroutine());
        }
    }

    public virtual void StopShoot()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }
    }

    protected abstract IEnumerator ShootCoroutine();

    protected void Shoot()
    {
        var obj = poolManager.GetPooledObject();
        obj.SetActive(true);
        obj.GetComponent<Projectile>().StartProjectile();
        obj.transform.position = positionToShoot.position;
        obj.transform.rotation = positionToShoot.rotation;
        
    }
}



