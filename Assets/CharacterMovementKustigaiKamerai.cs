using UnityEngine;

public class CharacterMovementKustigaiKamerai: MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;
    private Rigidbody rb;
    private Transform cameraTransform;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = (cameraTransform.right * moveHorizontal + cameraTransform.forward * moveVertical).normalized;
        movement.y = 0f; // Ensure the character doesn't move up/down

        rb.velocity = movement * speed;

        // Set the Speed parameter in the Animator to control animations
        animator.SetFloat("Speed", rb.velocity.magnitude);

        // Rotate the character to face the movement direction
        if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }
    }
}
