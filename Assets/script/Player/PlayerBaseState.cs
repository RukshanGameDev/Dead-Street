using UnityEngine;

public abstract class PlayerBaseState 
{
    protected PlayerController player;

    protected PlayerBaseState(PlayerController player)
    {
        this.player = player;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
}
