using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/State/PlayerState/PlayerState_Land", fileName = "PlayerState_Land")]
public class PlayerState_Land : PlayerState 
{
    [SerializeField] float stiffTime = 0.2f;
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(Vector3.zero);
        player.CanAirJump = false;
    }

    public override void LogicUpdate()
    {
        if (input.Jump || input.HasJumpBuffer)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }

        Debug.Log(StateDuration < stiffTime);
        if(StateDuration < stiffTime)
        {
            return;
        }

        if(input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }

        if(isAnimationFinished)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }

}