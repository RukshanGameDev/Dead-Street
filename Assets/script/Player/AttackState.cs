using UnityEngine;

internal class AttackState : PlayerBaseState
{
    private float Timer;
    public AttackState(PlayerController player) : base(player)
    {
    }
    public override void Enter()
    {
        Timer = 0f;
        player.Animator.SetTrigger("Attack");
        player.PlayerAttackHitbox.SetActive(true);
        player.EffectAudioSource.PlayOneShot(player.AxeSwing);
    }
    public override void Update()
    {

         Timer += Time.deltaTime;
        if (Timer >= 1.2f)
        {
            player.StateMachine.ChangeState(new IdleState(player));
        }
        
    }
    public override void Exit()
    {
        player.PlayerAttackHitbox.SetActive(false);
    }
}