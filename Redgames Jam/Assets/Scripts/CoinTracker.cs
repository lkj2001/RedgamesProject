using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinTracker : MonoBehaviour
{
    public TextMeshProUGUI currentScore, highScore, points;

    public Coins coin;

    public void Update()
    {
        currentScore.text = coin.currentScore.ToString();
        highScore.text = coin.highScore.ToString();
        points.text = coin.points.ToString();
    }
}
