using NUnit.Framework.Interfaces;
using UnityEngine;

internal class WalkState : PlayerBaseState
{
    public WalkState(PlayerController player) : base(player)
    {
    }
    public override void Enter()
    {
        player.Animator.SetFloat("Speed", 1f);
        player.MovementAudioSource.clip = player.playerWalking;
        player.MovementAudioSource.volume = 0.2f;
        player.MovementAudioSource.Play();
    }

    public override void Update()
    {
        player.Move();
        player.ApplyGravity();

        if (player.JumpPressed)
        {
            player.StateMachine.ChangeState(new JumpState(player));
            return;
        }

        if (player.MoveInput.magnitude < 0.1f)
        {
            player.StateMachine.ChangeState(new IdleState(player));
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            player.StateMachine.ChangeState(new Runstate(player));
            return;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            player.StateMachine.ChangeState(new CrouchWalkState(player));
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            player.StateMachine.ChangeState(new AttackState(player));
            return;
        }

    }
    public override void Exit()
    {
        player.MovementAudioSource.Stop();
    }
}