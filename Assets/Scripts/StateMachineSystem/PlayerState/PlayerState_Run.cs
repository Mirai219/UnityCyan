using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/State/PlayerState/PlayerState_Run", fileName = "PlayerState_Run")]
public class PlayerState_Run : PlayerState
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float acceleration = 5f;
    public override void Enter()
    {
        base.Enter();
        currentSpeed = player.MoveSpeed;
    }

    public override void LogicUpdate()
    {
        if(!input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }

        if(player.IsFalling)
        {
            stateMachine.SwitchState(typeof(PlayerState_CoyoteTime));
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceleration * Time.deltaTime);
    }

    public override void PhysicUpdate()
    {
        player.Move(currentSpeed);
    }
}
