using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene management

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;  // Player speed, editable in the Inspector
    public int health = 5;       // Variable to track health
    private int originalHealth;  // To store the initial health value
    private int score = 0;       // Variable to track score
    private int originalScore;   // To store the initial score value

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the Player object
        rb = GetComponent<Rigidbody>();

        // Store the initial values of health and score
        originalHealth = health;
        originalScore = score;
    }

    // FixedUpdate is called at a fixed interval, best for handling physics
    void FixedUpdate()
    {
        // Get input for movement (WASD or Arrow Keys)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector based on the input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply the movement to the Rigidbody to move the Player
        rb.AddForce(movement * speed);
    }

    // Called when another collider enters the trigger collider attached to this GameObject
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            // Increment the score
            score++;
            // Log the new score
            Debug.Log($"Score: {score}");
            // Disable the Coin object
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Trap"))
        {
            // Decrement the health
            health--;
            // Log the new health value
            Debug.Log($"Health: {health}");
            // Optionally, disable or destroy the Trap object if needed
            // other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Goal"))
        {
            // Log the winning message
            Debug.Log("You win!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            // Log the game over message
            Debug.Log("Game Over!");

            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // Reset health and score
            health = originalHealth;
            score = originalScore;
        }
    }
}
