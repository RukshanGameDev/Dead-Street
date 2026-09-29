using UnityEngine;
public class EnemyAttackState : IEnemyState
{
    private readonly EnemyController enemy;
    private float attackCooldown;
    public EnemyAttackState(
    EnemyController enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        enemy.Agent.isStopped = true;
        attackCooldown = 0f;
        enemy.Animator.SetTrigger(
        "Attack");
        enemy.AudioSource.clip = enemy.ZombieAttack;
       enemy.AudioSource.loop = false;
    }
    public void Update()
    {
        Transform player =
        enemy.Detection.GetPlayer();
        if (player == null)
        {
            enemy.StateMachine.ChangeState(
            new EnemyIdleState(enemy));
            return;
        }
        if(PlayerHealthSystem.instance.PlayerHealth <= 0f)
        {
            enemy.StateMachine.ChangeState(
            new EnemyIdleState(enemy));
            return;
        }
        Vector3 direction =
            player.position -
            enemy.transform.position;
        direction.y = 0f;
        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation =
            Quaternion.LookRotation(direction);
            enemy.transform.rotation =
            Quaternion.Slerp(
            enemy.transform.rotation,
            targetRotation,
            Time.deltaTime * 10f);
        }
        attackCooldown -=
            Time.deltaTime;
        if (attackCooldown <= 0f)
        {
            attackCooldown = 3f;
            PlayerHealthSystem.instance.TakeDamage(enemy.AttackDamage);
            enemy.Animator.SetTrigger(
            "Attack");
            enemy.AudioSource.Play();
        }
        if (!enemy.IsPlayerInAttackRange())
        {
            enemy.StateMachine.ChangeState(
            new EnemyChaseState(enemy));
        }

        

    }
    public void Exit()
    {
        enemy.Agent.isStopped = false;
        enemy.AudioSource.Stop();
        enemy.AudioSource.loop = true;
    }
}