using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int points;
    public int currentScore;
    public int highScore;
    public bool DoublePoint;

    public static CoinManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: To persist the CoinManager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
