using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    [Header("Audio Setting")]
    public AudioSource AudioSource;
    public AudioClip ZombieIdle;
    public AudioClip ZombieChase;
    public AudioClip ZombieAttack;


    [Header("Components")]
    public NavMeshAgent Agent { get; private set; }
    public Animator Animator { get; private set; }
    public EnemyDetection Detection { get; private set; }
    public EnemyCombat Combat { get; private set; }
    public InventoryManager Inventory
    {
        get;
        private set;
    }
    public PlayerController PlayerController { get; private set; }
    public EnemyHealthSytem EnemyHealth {  get; private set; }
    public Transform HomePoint { get; private set; }
    public EnemyStateMachine StateMachine
    {
        get;
        private set;
    }
    [Header("Settings")]
    [SerializeField]
    private Transform homePoint;
    [SerializeField]
    private float attackDistance = 1.5f;
    public float AttackDistance => attackDistance;
    public float AttackDamage = -10f;
    private void Awake()
    {
        PlayerController=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        EnemyHealth=gameObject.GetComponent<EnemyHealthSytem>();
        Agent =
        GetComponent<NavMeshAgent>();
        Animator =
        GetComponent<Animator>();
        Detection =
        GetComponent<EnemyDetection>();
        Combat =
        GetComponent<EnemyCombat>();
        Inventory =
        GetComponent<InventoryManager>();
        HomePoint = homePoint;
        StateMachine =
new EnemyStateMachine();
    }
    private void Start()
    {
        StateMachine.ChangeState(
        new EnemyIdleState(this));
    }
    private void Update()
    {
        StateMachine.Update();
        UpdateAnimator();
    }
    private void UpdateAnimator()
    {
        if (Animator == null)
            return;
        float speed =
            Agent.velocity.magnitude;
        Animator.SetFloat(
            "Speed",
            speed);
    }
    public bool IsPlayerInAttackRange()
    {
        Transform player =
        Detection.GetPlayer();
        if (player == null)
            return false;
        float distance =
        Vector3.Distance(
            transform.position,
            player.position);
            return distance <= attackDistance;
    }
}