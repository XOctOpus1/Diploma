using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 10f;    // Speed at which the player runs
    public float jumpForce = 5f;    // Force applied when the player jumps

    private Rigidbody rb;           // Reference to the player's Rigidbody
    private bool isGrounded = true;         // Flag to check if the player is on the ground

    void Start()
    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move the player forward constantly
        Vector3 forwardMove = transform.forward * runSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMove);

        // Check if the space button is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Apply jump force to the player's Rigidbody
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the character is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Lava"))
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        // Get the current active scene and reload it
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
