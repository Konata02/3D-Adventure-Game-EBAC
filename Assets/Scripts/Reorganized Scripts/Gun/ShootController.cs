using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ShootController : MonoBehaviour
{
    public List<GunBase> guns; // Lista de armas disponíveis
    private int currentGunIndex = 0; // Índice da arma atual

    private void Start()
    {
        if (guns.Count > 0)
        {
            EquipGun(currentGunIndex); // Equipar a arma inicial
        }
    }

    public void StartShooting()
    {
        guns[currentGunIndex]?.StartShoot();
    }

    public void StopShooting()
    {
        guns[currentGunIndex]?.StopShoot();
    }

    public void ChangeGun(int index)
    {
        if (index < 0 || index >= guns.Count) return; // Verifica se o índice é válido
        EquipGun(index);
    }

    private void EquipGun(int index)
    {
        // Para a arma atual, se existir
        if (currentGunIndex >= 0 && currentGunIndex < guns.Count)
        {
            guns[currentGunIndex].StopShoot();
            guns[currentGunIndex].gameObject.SetActive(false); // Desativa a arma
        }

        // Atualiza o índice da arma atual e ativa a nova arma
        currentGunIndex = index;
        guns[currentGunIndex].gameObject.SetActive(true); // Ativa a nova arma
    }

    public void NextGun()
    {
        int nextIndex = (currentGunIndex + 1) % guns.Count; // Cicla para a próxima arma
        EquipGun(nextIndex);
    }

    public void PreviousGun()
    {
        int prevIndex = (currentGunIndex - 1 + guns.Count) % guns.Count; // Cicla para a arma anterior
        EquipGun(prevIndex);
    }
}


/*public class ShootController : MonoBehaviour
{
    public GunBase currentGun;
    

    public void StartShooting()
    {
        currentGun?.StartShoot();
    }

    public void StopShooting()
    {
        currentGun?.StopShoot();
    }

    public void ChangeGun(GunBase newGun)
    {
        if (currentGun != null)
        {
            currentGun.StopShoot();
        }
        currentGun = newGun;
    }
}*/


/*
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
*/