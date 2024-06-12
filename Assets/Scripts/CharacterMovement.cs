using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    private CharacterController characterController;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized;

        if (movement.magnitude >= 0.01f)
        {
            // Move the character
            characterController.Move(movement * moveSpeed * Time.deltaTime);

            // Rotate the character to face the movement direction
            transform.forward = movement;

            // Update the animator parameter
            animator.SetFloat("Speed", movement.magnitude);
        }
        else
        {
            // Update the animator parameter to idle
            animator.SetFloat("Speed", 0);
        }
    }
}
