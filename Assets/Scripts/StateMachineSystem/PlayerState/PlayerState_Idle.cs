using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/State/PlayerState/PlayerState_Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    [SerializeField] float deceleration = 5f;
    public override void Enter()
    {
        base.Enter();
        currentSpeed = player.MoveSpeed;
    }

    public override void LogicUpdate()
    {
        if(input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }

        if (player.IsFalling)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
    }

    public override void PhysicUpdate()
    {
        player.SetVelocityX(currentSpeed * player.transform.localScale.x);
    }
}
