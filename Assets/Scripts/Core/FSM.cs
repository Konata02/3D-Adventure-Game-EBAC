using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
public class FSM : MonoBehaviour
{
    public enum stateExemple{
            NONE
    }

    public StateMachine<stateExemple> stateMachine;
    
    public void Start(){
        stateMachine = new StateMachine<stateExemple>();
        stateMachine.Init();
        stateMachine.RegisterStates(stateExemple.NONE, new StateBase());
    }




}
