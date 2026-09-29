using UnityEngine;

internal class CollectState : PlayerBaseState
{
    public CollectState(PlayerController player) : base(player)
    {
    }
    
    public override void Enter()
    {

        player.Animator.SetBool("isCollecting", true);

    }
    public override void Update()
    {
        player.ApplyGravity();

        if (!Input.GetKey(KeyCode.E))
        {
            player.Animator.SetBool("isCollecting", false);
            player.StateMachine.ChangeState(new IdleState(player));

        }
    }
}