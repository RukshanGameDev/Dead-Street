using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSytem : MonoBehaviour
{
    public static EnemyHealthSytem instance;
    [SerializeField]
    private float EnemyHealth = 100f;

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
        HealthSlider.value = EnemyHealth;
    }
    public void TakeDamage(float damage)
    {
        EnemyHealth += damage;
        UpdateUI();
        if (EnemyHealth <= 0f)
        {
            Die();
            EnemyHealth = 0f;
        }
    }
    public void Die()
    {
        EnemyController enemyController=gameObject.GetComponent<EnemyController>();
        enemyController.StateMachine.ChangeState(
            new EnemyDeadState(enemyController));
    }
}
