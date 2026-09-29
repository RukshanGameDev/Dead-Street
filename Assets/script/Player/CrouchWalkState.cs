using UnityEngine;

internal class CrouchWalkState : PlayerBaseState
{
    public CrouchWalkState(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
        player.Animator.SetBool("isCrouching", true);
        player.Animator.SetFloat("Speed", 1f);
        player.moveSpeed = player.moveSpeed/2;



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
            player.StateMachine.ChangeState(new CrouchState(player));
        }

        if (Input.GetKey(KeyCode.LeftShift) && player.MoveInput.magnitude > 0.1f)
        {
            player.StateMachine.ChangeState(new Runstate(player));
            return;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            player.StateMachine.ChangeState(new WalkState(player));
            return;
        }
    }
    public override void Exit()
    {
        player.moveSpeed = player.moveSpeed * 2;
        player.Animator.SetBool("isCrouching", false);
    }
   
}