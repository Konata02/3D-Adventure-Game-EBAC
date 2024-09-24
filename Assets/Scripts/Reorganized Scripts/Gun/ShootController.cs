using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ShootController : MonoBehaviour
{
    
    public PoolManager poolManager;
    public Transform positionToShoot;
    public float timeBetweenShoot = .2f;
    public float timeBetweenShootMinus = .1f;
    private Coroutine _currentCoroutine; 
    public bool change = false;
    public int shootsPerClick = 3;
    
   
    IEnumerator ShootCoroutine(){
        
            if (change == false){
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
            }

            else {
                for (int i = 0; i <= shootsPerClick ; i++){
                    Shoot();
                    yield return new WaitForSeconds(timeBetweenShoot - timeBetweenShootMinus);
                }
            }
      
    }

    public void StartShoot(){
        //StopShoot()
        _currentCoroutine = StartCoroutine(ShootCoroutine());
        
    }

    public void StopShoot(){
        if(_currentCoroutine != null) StopCoroutine(_currentCoroutine);
    }

    public void ChangeFireType (){
        change = !change;
    }


    private void Shoot(){
        var obj = poolManager.GetPooledObject();
        obj.SetActive(true);
        obj.GetComponent<Projectile>().StartProjectile();
        obj.transform.position = positionToShoot.transform.position;
        obj.transform.rotation = positionToShoot.transform.rotation;
    }

}