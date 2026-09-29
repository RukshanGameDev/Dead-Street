public class EnemyStateMachine
{
    public IEnemyState CurrentState { get; private set; }
    public void ChangeState(IEnemyState newState)
    {
        if (newState == null)
            return;
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
    public void Update()
    {
        CurrentState?.Update();
    }
}
