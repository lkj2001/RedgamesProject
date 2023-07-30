using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject Tutorial, bg1, bg2;
    public void Retry()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MainMenu()
    {
        Tutorial.SetActive(true);
        bg1.SetActive(false);
        bg2.SetActive(true);
    }

    public void tutorial()
    {
        Tutorial.SetActive(false);
        bg1.SetActive(true);
        bg2.SetActive(false);
    }

    public void StartGame()
    {
        //SceneManager.LoadScene("Doha");
        SceneManager.LoadScene("SampleScene");
    }
}
