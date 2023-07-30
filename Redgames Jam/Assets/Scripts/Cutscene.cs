using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public VideoPlayer video;
    private bool hasStartedTransition = false;

    private void Start()
    {
        video.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer source)
    {
        // Make sure the event is triggered by the intended VideoPlayer component
        if (source == video && !hasStartedTransition)
        {
            hasStartedTransition = true;
            Invoke("nextScene", 0f);
        }
    }

    public void nextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
