using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Singleton;
using DG.Tweening;
using StateMachine;

public class GameManager : Singleton<GameManager>
{
/*
    [Header("Player")]
    public GameObject player;

    [Header("Enemies")]
    public List<GameObject> enemies;
*/

    public enum GameStates{
        INTRO,
        GAMEPLAY,
        PAUSE,
        WIN,
        LOSE
    }

    public StateMachine<GameStates> stateMachine;

    private void Start (){

        Init();
    }

    public void Init(){

        stateMachine = new StateMachine<GameStates>();
        stateMachine.Init();
        stateMachine.RegisterStates(GameStates.INTRO, new StateBase());
        stateMachine.RegisterStates(GameStates.GAMEPLAY, new StateBase());
        stateMachine.RegisterStates(GameStates.PAUSE, new StateBase());
        stateMachine.RegisterStates(GameStates.WIN, new StateBase());
        stateMachine.RegisterStates(GameStates.LOSE, new StateBase());

        stateMachine.SwitchState(GameStates.GAMEPLAY);




    }

    public void InitGame(){

    }
    

   //[Header("References")]
   
   //public Transform startPoint;
   //private GameObject _currentPlayer;
   //public float duration = .2f;
   //public float delay = .05f;
   //public Ease ease = Ease.OutBack;


}
