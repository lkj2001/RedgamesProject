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

    [Header("Animation")]
    public Animator animator;
    private Quaternion targetRotation = Quaternion.identity;
    public float rotation = -20f;
    public float rotationSpeed = 2f; //Slower = smoother transition

    [Header("Other stuff")]
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private PowerupManager powerUpManager;
    public bool isShielded;
    public GameObject shield;
    public PowerUp powerUp;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        powerUpManager = FindObjectOfType<PowerupManager>();
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

        if(isShielded)
        {
            shield.SetActive(true);
            Invoke("stopIceCream", 10f);
        }
        else
        {
            shield.SetActive(false);
            powerUpManager.SetPowerUpActive(PowerType.IceCream, false);
            CancelInvoke("stopIceCream");
        }

        //Moving forward
        rb.velocity = new Vector2(speed, rb.velocity.y);

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
            targetRotation = Quaternion.Euler(0f, 0f, rotation);
        }
        else
        {
            
            rb.AddForce(new Vector2(0f, -jumpForce * gravityMultiplier * (rb.mass * Downforce)), ForceMode2D.Force);
            targetRotation = Quaternion.identity;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

    }

    private void StartJump()
    {
        animator.Play("Fly");
        isJumping = true;
    }

    private void EndJump()
    {
        animator.Play("Default", 0, 0.0f); //Smoothly transition into default animation
        isJumping = false;
    }

    public void stopIceCream()
    {
        Debug.Log("Shield Destroyed");
        powerUpManager.SetPowerUpActive(PowerType.IceCream, false);
        isShielded = false;
        CancelInvoke("stopIceCream");
    }
}
