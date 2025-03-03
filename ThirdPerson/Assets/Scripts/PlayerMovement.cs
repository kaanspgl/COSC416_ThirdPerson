using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public Transform cameraTransform;

    private Vector3 velocity;
    private bool isGrounded;
    private int jumpCount = 0; // Tracks the number of jumps
    public int maxJumps = 2; // Set to 2 for double jump

    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.2f;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded)
        {
            jumpCount = 0; // Reset jumps when touching the ground
            if (velocity.y < 0)
                velocity.y = -2f; // Reset gravity when grounded
        }

        // Get input from WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // Double Jump Mechanic
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpCount++;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
