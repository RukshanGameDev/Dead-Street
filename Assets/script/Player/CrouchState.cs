using UnityEngine;

    internal class CrouchState : PlayerBaseState
{
    public CrouchState(PlayerController player) : base(player)
    {

    }

    public override void Enter()
    {

        player.Animator.SetBool("isCrouching", true);
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

        if (player.MoveInput.magnitude > 0.1f )
        {
            player.StateMachine.ChangeState(new CrouchWalkState(player));     
        }

       
        if (Input.GetKeyDown(KeyCode.C))
        {
            player.StateMachine.ChangeState(new IdleState(player));
            return;
        }
    }
    public override void Exit()
    {
        player.Animator.SetBool("isCrouching", false);

    }
}

