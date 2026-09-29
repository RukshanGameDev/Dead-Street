using UnityEngine;
public class EnemyChaseState : IEnemyState
{
    private readonly EnemyController enemy;
    public EnemyChaseState(
    EnemyController enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        enemy.Agent.isStopped = false;
        enemy.AudioSource.clip = enemy.ZombieChase;
        enemy.AudioSource.Play();
    }
    public void Update()
    {
        Transform player =
            enemy.Detection.GetPlayer();
        if (player == null)
            return;
        if (!enemy.Detection.CanDetectPlayer())
        {
            enemy.StateMachine.ChangeState(
            new EnemyIdleState(enemy));
            return;
        }
        if (enemy.IsPlayerInAttackRange())
        {
            enemy.StateMachine.ChangeState(
            new EnemyAttackState(enemy));
            return;
        }


        //enemy move to player
        enemy.Agent.SetDestination(
            player.position);
    }
    public void Exit()
    {
        enemy.AudioSource.Stop();
    }
}
