public class EnemyDeadState : IEnemyState
{
    private readonly EnemyController enemy;
    public EnemyDeadState(EnemyController enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        enemy.Animator.SetTrigger("Dead");
        enemy.transform.Find("Canvas").gameObject.SetActive(false);
    }

    
    public void Update()
    {
    }
    public void Exit()
    {
    }

}