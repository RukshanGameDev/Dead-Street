using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float rotationSpeed = 10f;

    [Header("References")]
    public Animator Animator;
    public GameObject PlayerAttackHitbox;
    public float AttackDamage;

    [Header("Audio Setting")]
    public AudioSource MovementAudioSource;
    public AudioSource EffectAudioSource;
    public AudioClip playerWalking;
    public AudioClip playerRunning;
    public AudioClip AxeSwing;

    [Header("UI")]
    public GameObject GameOverMenu;

    [Header("Jump")]
    public float jumpHegiht = 5f;
    public float gravity = -9.81f;
    private Vector3 velocity;

    public bool IsGrounded { get; private set; }
    public bool JumpPressed => Input.GetButtonDown("Jump");

    public CharacterController CharacterController { get; private set; }
    public Vector2 MoveInput { get; private set; }
    public StateMachine StateMachine { get; private set; }

    private Camera mainCamera;

   

    void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        mainCamera = Camera.main;

        StateMachine = new StateMachine();
        PlayerAttackHitbox.SetActive(false);
        
    }

    void Start()
    {
        StateMachine.ChangeState(new IdleState(this));
    }

    void Update()
    {
        MoveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        GroundCheck();
        StateMachine.Update();

    }

  
    private void GroundCheck()
    {
        IsGrounded = CharacterController.isGrounded;

        Animator.SetBool("Grounded", IsGrounded);

        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    public void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHegiht * -2f * gravity);
    }



    public void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        CharacterController.Move(velocity * Time.deltaTime);
    }

    public void Move()
    {
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 direction =
            forward * MoveInput.y +
            right * MoveInput.x;

        CharacterController.Move(direction.normalized * moveSpeed * Time.deltaTime);

        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime);
        }
    }
    
}
