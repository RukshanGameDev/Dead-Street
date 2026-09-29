internal class JumpState : PlayerBaseState
{
    public JumpState(PlayerController player) : base(player)
    {
    }
    override public void Enter()
    {
        player.Animator.SetTrigger("Jump");
        player.Jump();
    }

    public override void Update()
    {
        player.Move();
        player.ApplyGravity();

        if (player.IsGrounded)
        {
            if (player.MoveInput.magnitude > 0.1f)
            {
                player.StateMachine.ChangeState(new WalkState(player));
            }
            else
            {
                player.StateMachine.ChangeState(new IdleState(player));
            }
        }
    }
}