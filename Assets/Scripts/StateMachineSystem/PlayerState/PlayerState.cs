using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    [SerializeField] string stateName;
    [SerializeField, Range(0f, 1f)] float transitionDuration = 0.1f; 
    int stateHash; 
    protected Animator animator;
    protected PlayerStateMachine stateMachine;
    protected PlayerInput input;
    protected PlayerController player;

    protected float currentSpeed;

    protected float stateStartTime;
    protected float StateDuration => Time.time - stateStartTime;
    protected bool isAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;

    public void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);
    }
    public void Initialize(Animator animator, PlayerStateMachine stateMachine, PlayerInput input,PlayerController playerController)
    {
        this.animator = animator;
        this.stateMachine = stateMachine;
        this.input = input;
        this.player = playerController;
    }

    public virtual void Enter()
    {
        animator.CrossFade(stateHash,transitionDuration);
        stateStartTime = Time.time;
    }

    public virtual void Exit()
    {
       
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicUpdate()
    {
        
    }
}
