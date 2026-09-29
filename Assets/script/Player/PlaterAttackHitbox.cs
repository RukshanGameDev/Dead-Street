using UnityEngine;

public class PlaterAttackHitbox : MonoBehaviour
{
    [SerializeField] private float AttackDamage;
    public AudioSource AudioSource;
    public AudioClip AttackHit;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            EnemyController enemyController = other.GetComponent<EnemyController>();


            if (enemyController != null)
            {
                this.AudioSource.PlayOneShot(AttackHit);
                enemyController.StateMachine.ChangeState(new EnemyAttackHitState(enemyController));
            }
        }
    }
}
