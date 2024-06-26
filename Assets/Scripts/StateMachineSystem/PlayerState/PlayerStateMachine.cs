using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    Animator animator;
    PlayerInput input;
    PlayerController playerController;
    [SerializeField] PlayerState[] states;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        input = GetComponentInChildren<PlayerInput>();
        stateTable = new Dictionary<System.Type, IState> (states.Length);
        playerController = GetComponentInChildren<PlayerController>();
        foreach (var state in states)
        {
            state.Initialize(animator,this,input,playerController);
            stateTable.Add(state.GetType(), state);
        }
    }

    void Start()
    {
        SwitchOn(typeof(PlayerState_Idle));
    }
}
