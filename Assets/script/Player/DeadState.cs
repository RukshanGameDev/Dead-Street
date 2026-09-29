using UnityEngine;

internal class DeadState : PlayerBaseState
{
    private float Timer;
    public DeadState(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
        Timer = 0f;
        player.Animator.SetTrigger("Dead");
       
    }
    public override void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 3f)
        {
            player.GameOverMenu.SetActive(true);
             Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }
}