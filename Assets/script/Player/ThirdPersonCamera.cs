using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distance = 5f;
    [SerializeField] private float height = 2f;
    [SerializeField] private float mouseSensitivity = 3f;
    [SerializeField] private float smoothSpeed = 10f;

    private float rotationX;
    private float rotationY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void LateUpdate()
    {
        // Mouse input
        rotationY += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Limit vertical rotation
        rotationX = Mathf.Clamp(rotationX, -30f, 60f);

        // Camera rotation
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0f);

        // Camera position
        Vector3 targetPosition =
            player.position + Vector3.up * height
            - rotation * Vector3.forward * distance;

        // Smooth follow
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.rotation = rotation;
    }
}