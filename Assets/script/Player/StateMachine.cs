using UnityEngine;

public class StateMachine 
{
    public PlayerBaseState CurrentState { get; private set; }

    public void ChangeState(PlayerBaseState newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    public void Update()
    {
        CurrentState?.Update();
    }

    public void FixedUpdate()
    {
        CurrentState?.FixedUpdate();
    }
}
