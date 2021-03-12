using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventSceneChange : MonoBehaviour, IActivateable
{
    public AudioSource source;
    public string subtitle;
    Subtitles subtitles;
    public string sceneName;

    SceneManager manager;

    public bool hasActivated { get; set; }

    public void activate()
    {
        if (!hasActivated)
        {
            subtitles = GameObject.Find("Subtitles").GetComponent<Subtitles>();
            subtitles.newText = subtitle;
            playSound();

            hasActivated = true;

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }

    public void playSound()
    {
        source.Stop();
        source.Play();
    }
}
