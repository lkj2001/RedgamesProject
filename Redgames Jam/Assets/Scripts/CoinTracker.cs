using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinTracker : MonoBehaviour
{
    public TextMeshProUGUI currentScore, highScore, points;

    //public CoinManager CM;

    public void Update()
    {
        currentScore.text = CoinManager.Instance.currentScore.ToString();
        highScore.text = CoinManager.Instance.highScore.ToString();
        points.text = CoinManager.Instance.points.ToString();
    }
}
