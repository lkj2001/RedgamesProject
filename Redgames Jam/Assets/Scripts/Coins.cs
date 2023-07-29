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
                CoinManager.Instance.currentScore += 200;
                CoinManager.Instance.points += 1;
            }
            else
            {
                CoinManager.Instance.currentScore += 100;
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
