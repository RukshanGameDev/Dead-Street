using UnityEngine;

internal class EnemyAttackHitState : IEnemyState
{

    private readonly EnemyController enemy;
    private float timer;
    public EnemyAttackHitState(
    EnemyController enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        enemy.EnemyHealth.TakeDamage(enemy.PlayerController.AttackDamage);
        enemy.Animator.Play("AttackHit", 0, 0f);
        enemy.Animator.SetTrigger("AttackHit");
        timer = 0;
    }

    public void Exit()
    {
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            enemy.StateMachine.ChangeState(
            new EnemyAttackState(enemy));
        }
    }
}