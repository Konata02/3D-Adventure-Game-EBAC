using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityBase : MonoBehaviour
{
    public Player player; 

    public PlayerInput inputs; 

    private void OnValidate()
    {
        if (player == null) player = GetComponent<Player>();
    }

    private void Start()
    {
        inputs = new PlayerInput(); 
        inputs.Enable();

        Init();
        RegisterListener();
    }

    private void OnEnable()
    {
        if (inputs != null) inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    private void OnDestroy()
    {
        RemoveListeners();
    }

    protected virtual void Init()
    {
       
    }

    protected virtual void RegisterListener()
    {
       
    }

    protected virtual void RemoveListeners()
    {
        
    }
}