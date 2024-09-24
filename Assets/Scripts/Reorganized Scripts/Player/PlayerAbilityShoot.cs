using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAbilityShoot : PlayerAbilityBase
{
 
    public ShootController shootController;

    protected override void Init(){
        base.Init();
        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        //inputs.Gameplay.Shoot.canceled += cts => CancelShoot();
        inputs.Gameplay.ChangeWeapon.performed += cts => ChangeFireType();

    }


    private void StartShoot(){
        Debug.Log("Atirou");
        shootController.StartShoot();
    }

    private void CancelShoot(){
        shootController.StopShoot();
    }

    private void ChangeFireType(){
        shootController.ChangeFireType();
    }
    

}
