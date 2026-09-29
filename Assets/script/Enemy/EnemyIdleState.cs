using UnityEngine;
public class EnemyIdleState : IEnemyState
{
    private readonly EnemyController enemy;
    public EnemyIdleState(
    EnemyController enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        enemy.Agent.isStopped = true;
        enemy.AudioSource.clip = enemy.ZombieIdle;
        enemy.AudioSource.Play();
    }
    public void Update()
    {
        if (enemy.Detection.CanDetectPlayer() && (enemy.PlayerController.StateMachine.CurrentState is WalkState
            || enemy.PlayerController.StateMachine.CurrentState is Runstate))
        {
            Debug.Log("player detected");
            enemy.StateMachine.ChangeState(
            new EnemyChaseState(enemy));
        }
        else if (enemy.Detection.L1CanDetectPlayer())
        {
            Debug.Log("player detected");
            enemy.StateMachine.ChangeState(
            new EnemyChaseState(enemy));
        }
       
        
    }
    public void Exit()
    {
        enemy.Agent.isStopped = false;
        enemy.AudioSource.Stop();
    }
}
