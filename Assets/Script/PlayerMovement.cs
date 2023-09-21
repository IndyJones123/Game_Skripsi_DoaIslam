using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust the speed as needed
    public float rotationSpeed = 2.0f; // Adjust the rotation speed as needed

    private Animator animator;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        

        // Calculate the movement direction based on the player's forward direction
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        // Move the player's GameObject
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Rotate the player based on mouse input
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0, mouseX * rotationSpeed, 0);
        transform.Rotate(rotation);

        

        // Normalize the movement vector to ensure consistent speed in all directions
        if (movement.magnitude > 0.1f)
        {
            movement.Normalize();   

            animator.SetBool("Run", true);
            Debug.Log("test");

            movement = transform.TransformDirection(movement); // Convert to world space
        }
        else
        {
            animator.SetBool("Run", false);
        }
        

    }
}
