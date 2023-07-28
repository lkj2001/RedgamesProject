using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float gravityMultiplier = 2f; // Adjust this value to control the descent speed
    private Rigidbody2D rb;
    private bool isJumping = false;
    public float Upforce = 1f;
    public float Downforce = 0.5f;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        // Handle horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Check for jump input
        if (Input.GetMouseButtonDown(0))
        {
            StartJump();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndJump();
        }

        // Apply continuous upward force while holding down the mouse button
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce * (rb.mass * Upforce)), ForceMode2D.Force); 
        }
        else // If not jumping, apply additional downward force for faster descent
        {
            rb.AddForce(new Vector2(0f, -jumpForce * gravityMultiplier * (rb.mass * Downforce)), ForceMode2D.Force);
        }
    }

    private void StartJump()
    {
        isJumping = true;
    }

    private void EndJump()
    {
        isJumping = false;
    }
}
