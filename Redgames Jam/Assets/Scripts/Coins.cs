using UnityEngine;

public class Coins : MonoBehaviour
{
    //public CoinManager CoinManager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (CoinManager.Instance.DoublePoint)
            {
                CoinManager.Instance.currentScore += 20;
                CoinManager.Instance.points += 1;
            }
            else
            {
                CoinManager.Instance.currentScore += 10;
                CoinManager.Instance.points += 1;
            }

            if (CoinManager.Instance.currentScore >= CoinManager.Instance.highScore) //Update highscore
            {
                CoinManager.Instance.highScore = CoinManager.Instance.currentScore;
            }

            Destroy(gameObject);
        }
    }
}
