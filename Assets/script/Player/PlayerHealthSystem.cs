using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    public static PlayerHealthSystem instance;
    public float PlayerHealth = 100f;

    public Slider HealthSlider;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        HealthSlider.minValue = 0f;
        HealthSlider.maxValue = 100f;
        UpdateUI();
    }

    void Update()
    {
        
    }

   
   

    private void UpdateUI()
    {
        HealthSlider.value = PlayerHealth;
    }
    public void TakeDamage(float damage)
    {

        PlayerHealth += damage;
        UpdateUI();
        if (PlayerHealth <= 0f)
        {
            Die();
            PlayerHealth = 0f;
        }
    }
    public void Die()
    {
        PlayerController playerController=gameObject.GetComponent<PlayerController>();
        playerController.StateMachine.ChangeState(new DeadState(playerController));
    }
}
