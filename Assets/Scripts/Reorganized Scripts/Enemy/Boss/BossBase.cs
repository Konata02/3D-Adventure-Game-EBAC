using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using DG.Tweening;


namespace Boss
{

    public enum BossAction
    {
        INIT, 
        IDLE,
        WALK,
        ATTACK
    }



public class BossBase : MonoBehaviour
{

    [Header("Animation")]
    public float startAnimationDuration  =5f;
    public Ease startAnimation = Ease.OutBack;
    private StateMachine<BossAction> stateMachine;
    public float speed = 5f;
    public List<Transform> waypoints;

    public float timeBetweenShots = 1;
    public int amoutShoots = 5;

    public GunBase gunBase;

    private void Awake()
    {
        Init();
    }

    

    private void Init(){
        stateMachine = new StateMachine<BossAction>();
        stateMachine.Init();

        stateMachine.RegisterStates(BossAction.INIT, new BossStateInit());
        stateMachine.RegisterStates(BossAction.WALK, new BossStateWalk());
        stateMachine.RegisterStates(BossAction.ATTACK, new BossStateAttack());

    }
 

#region ATTACK 

  
  public void Shoot()
    {
        StartCoroutine(StartShooting());
    }

  
  IEnumerator StartShooting ()
    {
        for (int i = 0 ; i <= amoutShoots; i++)
        {
            gunBase.StartShoot();
            yield return new WaitForSeconds(timeBetweenShots);
        }
            
        
    }  

//gunBase.StartShoot();

#endregion

#region  WALK

    public void GoToRandomPoint ()
    {
        StartCoroutine(GoToPointCoroutine(waypoints[Random.Range(0,waypoints.Count)]));
    }

    IEnumerator GoToPointCoroutine (Transform t)
    {
        while(Vector3.Distance(transform.position, t.position) > 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, t.position, Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        }
    }

#endregion

#region ANIMATION 

    public void StartInitAnimation()
    {
        transform.DOScale(0, startAnimationDuration).SetEase(startAnimation).From();
    }

#endregion

#region REGION DEBUG
    [NaughtyAttributes.Button]
    public void SwitchInit()
    {
        SwitchState(BossAction.INIT );
    }

    [NaughtyAttributes.Button]
    public void SwitchWalk()
    {
        SwitchState(BossAction.WALK );
    }

    [NaughtyAttributes.Button]
    public void SwitchAttack()
    {
        SwitchState(BossAction.ATTACK );
    }


#endregion

#region STATE MACHINE 

    public void SwitchState( BossAction state){

        stateMachine.SwitchState(state, this);

    }

#endregion

}



}