using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public bool KL; // Boolean to indicate if KL scene should be loaded
    public bool Doha; // Boolean to indicate if Doha scene should be loaded
    public bool SH; // Boolean to indicate if SH scene should be loaded

    // Called when another 2D collider enters the trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Load the appropriate scene based on the boolean values
            if (KL)
            {
                SceneManager.LoadScene("KL"); // Replace "KLScene" with the name of your Kuala Lumpur scene
            }
            else if (Doha)
            {
                SceneManager.LoadScene("Doha"); // Replace "DohaScene" with the name of your Doha scene
            }
            else if (SH)
            {
                SceneManager.LoadScene("SH"); // Replace "SHScene" with the name of your Shanghai scene
            }
        }
    }
}
