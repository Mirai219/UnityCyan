using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/State/PlayerState/PlayerState_JumpUp", fileName = "PlayerState_JumpUp")]
public class PlayerState_JumpUp : PlayerState
{
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float moveSpeed = 5f;
    public override void Enter()
    {
        base.Enter();
        input.HasJumpBuffer = false;
        player.SetVelocityY(jumpForce);
    }

    public override void LogicUpdate()
    {
        if (input.StopJump || player.IsFalling)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }

    public override void PhysicUpdate()
    {
        player.Move(moveSpeed);
    }
}
