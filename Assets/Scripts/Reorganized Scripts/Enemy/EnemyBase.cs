using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    //public Animator ANIM_Enemy;
    public HealthBase healthBase; 

    private void OnCollisionEnter(Collision collision){

        //Debug.Log(collision.transform.name);
        var health = collision.gameObject.GetComponent<HealthBase>();
        Player p = collision.transform.GetComponent<Player>();

        if (health != null){
            health.Damage(damage);
          // ANIM_Enemy.SetTrigger("atackEnemy");
        }

        if(p != null){

        }
        
    }



    public void Damage(int amount){
        healthBase.Damage(amount);
    }

    

}
