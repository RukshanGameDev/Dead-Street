using UnityEngine;

internal class PlacedState : PlayerBaseState
{
    public PlacedState(PlayerController player) : base(player)
    {
    }
    public override void Enter()
    {
        player.Animator.SetBool("isPlacing",true);
        
    }

    public override void Update()
    {
        player.ApplyGravity();

        if (!Input.GetKey(KeyCode.R))
        {
            player.Animator.SetBool("isPlacing", false);
            player.StateMachine.ChangeState(new IdleState(player));

        }
    }
}