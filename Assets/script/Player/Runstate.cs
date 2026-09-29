using UnityEngine;

internal class Runstate : PlayerBaseState
{
    public Runstate(PlayerController player) : base(player)
    {
    }
    override public void Enter()
    {
        player.Animator.SetTrigger("Run");
        player.moveSpeed = player.moveSpeed * 1.3f;
        player.MovementAudioSource.clip = player.playerRunning;
        player.MovementAudioSource.volume = 0.6f;
        player.MovementAudioSource.Play();
    }

    public override void Update()
    {
        player.Move();
        player.ApplyGravity();


        if ( !Input.GetKey(KeyCode.LeftShift))
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
    public override void Exit()
    {
        player.moveSpeed = player.moveSpeed / 1.3f;
        player.MovementAudioSource.Stop();
    }
}