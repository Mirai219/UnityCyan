using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/State/PlayerState/PlayerState_Fall", fileName = "PlayerState_Fall")]
public class PlayerState_Fall : PlayerState
{
    [SerializeField] AnimationCurve speedCurve;
    [SerializeField] float moveSpeed = 5f;

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if(player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerState_Land));
        }

        if (input.Jump)
        {
            if(player.CanAirJump)
            {
                stateMachine.SwitchState(typeof (PlayerState_AirJump));
                return;
            }
            input.SetJumpBufferInputTimer();
        }
    }

    public override void PhysicUpdate()
    {
        player.SetVelocityY(speedCurve.Evaluate(StateDuration));
        player.Move(moveSpeed);
    }

    
}