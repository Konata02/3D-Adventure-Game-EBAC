using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;


namespace StateMachine{

public class StateMachine<T> where T : System.Enum 
{

    public Dictionary <T, StateBase> dictionaryState;
    
    private StateBase _currentState;
    public float timeToStartGame = 1f;
    
    
    public StateBase CurrentState {
        get {return _currentState;}
    }

    /*public StateMachine(T state){
        
        SwitchState(state);
    
    }*/

    public void Init(){

        dictionaryState = new Dictionary<T, StateBase>();
       
    }

    public void RegisterStates(T typeEnum, StateBase state){

        dictionaryState.Add(typeEnum, state);
    }


    public void SwitchState(T state){
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = dictionaryState[state];

        _currentState.OnStateEnter();
    }

    public void Update(){
        if( _currentState != null) _currentState.OnStateStay();

        //if(Input.GetKeyDown(KeyCode.O)) SwitchState(States.NONE);
    }

}

}
/*#if UNITY_EDITOR
#region DEBUG
     [Button]
        
    private void ChangeStateToStateX(){
        SwitchState(States.NONE);
    }

#endregion
#endif*/