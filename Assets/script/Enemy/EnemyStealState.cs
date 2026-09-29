using UnityEngine;
public class EnemyStealState : IEnemyState
{
    private readonly EnemyController enemy;
    public EnemyStealState(
    EnemyController enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        enemy.Agent.isStopped = true;
    }
    public void Update()
    {
    }
    public void Exit()
    {
    }
}
