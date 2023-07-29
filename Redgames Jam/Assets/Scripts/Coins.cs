using UnityEngine;

public class Coins : MonoBehaviour
{
    public int points;
    public int currentScore;
    public int highScore;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentScore += 10;
            points += 1;

            if (currentScore >= highScore) //Update highscore
            {
                highScore = currentScore;
            }

            Debug.Log("Coin collected");
            Debug.Log("Current Score: " + currentScore);
            Debug.Log("High Score: " + highScore);

            Destroy(gameObject);
        }
    }
}
