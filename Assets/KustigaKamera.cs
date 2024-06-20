using UnityEngine;

public class KustigaKamera : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float mouseSensitivity = 100f; // Sensitivity of the mouse movement
    public float distanceFromPlayer = 2f; // Distance of the camera from the player

    private float pitch = 0f; // Up and down rotation
    private float yaw = 0f; // Left and right rotation

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Update yaw and pitch based on mouse input
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f); // Limit the pitch to avoid flipping

        // Rotate the camera
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        // Position the camera behind the player
        transform.position = player.position - transform.forward * distanceFromPlayer;
    }
}
