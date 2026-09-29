using NUnit.Framework.Interfaces;
using UnityEngine;

public class IdleState : PlayerBaseState
{
    public IdleState(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
        player.Animator.SetFloat("Speed", 0f);
    }

    public override void Update()
    {
        player.ApplyGravity();

        if (player.JumpPressed)
        {
            player.StateMachine.ChangeState(new JumpState(player));
            return;
        }

        if (player.MoveInput.magnitude > 0.1f)
        {
            player.StateMachine.ChangeState(new WalkState(player));
        }

        if (Input.GetKey(KeyCode.LeftShift) && player.MoveInput.magnitude > 0.1f)
        {
            player.StateMachine.ChangeState(new Runstate(player));
            return;
        }
        if (Input.GetKeyDown(KeyCode.C) )
        {
            player.StateMachine.ChangeState(new CrouchState(player));
            return;
        }
        if (Input.GetMouseButtonDown(0) )
        {
            player.StateMachine.ChangeState(new AttackState(player));
            return;
        }
       

    }
}
