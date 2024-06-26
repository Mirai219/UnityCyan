using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/State/PlayerState/PlayerState_AirJump", fileName = "PlayerState_AirJump")]
public class PlayerState_AirJump : PlayerState
{
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float moveSpeed = 5f;
    public override void Enter()
    {
        base.Enter();
        player.CanAirJump = false;
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
