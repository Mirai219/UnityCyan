using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/State/PlayerState/PlayerState_CoyoteTime", fileName = "PlayerState_CoyoteTime")]
public class PlayerState_CoyoteTime : PlayerState
{
    [SerializeField] float CoyoteTime;
    public override void Enter()
    {
        base.Enter();
        player.DiasbleGravity();
        currentSpeed = player.MoveSpeed;
    }

    public override void LogicUpdate()
    {

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }

        if (StateDuration > CoyoteTime || !input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }

    }

    public override void Exit()
    {
        player.EnableGravity();
    }

    public override void PhysicUpdate()
    {
        player.Move(currentSpeed);
    }
}
