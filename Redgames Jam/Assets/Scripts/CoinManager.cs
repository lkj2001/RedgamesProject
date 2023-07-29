using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int points;
    public float currentScore;
    public float highScore;
    public bool DoublePoint;
    private float timeSinceLastUpdate = 0f;
    //private const float scoreIncreaseInterval = 1f;

    public static CoinManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {

        //This allows the score to update by 10 every second (change the 1f if you want it to go faster/slower)
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= 1f)
        {
            int intervalsPassed = Mathf.FloorToInt(timeSinceLastUpdate / 1f);

            currentScore += intervalsPassed * 10;

            timeSinceLastUpdate -= intervalsPassed * 1f;

            if (currentScore >= highScore)
            {
                highScore = currentScore;
            }
        }
    }
}
