using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public enum State
{
    Normal,
    Invicible
}
public class Player : MonoBehaviour
{
    [Header("State")]
    public State State;

    [Header("Variables")]
    public float speed = 1; //best to edit in editor
    public float jumpForce = 10f; //When player goes up
    public float gravityMultiplier = 2f; //When player falls
    private bool isJumping = false;
    public float Upforce = 1f; //When player goes up
    public float Downforce = 0.5f; //When player falls
    public float propel = 1f; //moves the player forward

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        if(State == State.Invicible)
        {
            bc.isTrigger = true;
        }
        else if(State == State.Normal) 
        {
            bc.isTrigger = false;
        }
        // Handle horizontal movement
        //float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(/*horizontalInput **/ speed, rb.velocity.y);

        // Check for jump input
        if (Input.GetMouseButtonDown(0))
        {
            StartJump();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndJump();
        }

        if (isJumping)
        {
            rb.AddForce(new Vector2(propel, jumpForce * (rb.mass * Upforce)), ForceMode2D.Force); 
        }
        else
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
