using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventGoToScene : MonoBehaviour, IActivateable
{

    SceneManager sceneManager;
    public bool locked = false;
    public AudioSource source;
    public string lockedSubtitle;
    public string openedSubtitle;
    public AudioClip lockedClip;
    public AudioClip openedClip;
    Subtitles subtitles;

    public bool hasActivated { get; set; }

    public void activate()
    {
        subtitles = GameObject.Find("Subtitles").GetComponent<Subtitles>();
        sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
        if (!locked)
        {
            sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
            sceneManager.currentScene.GetComponent<Room>().GoToRoom("Interact");
        }
        else if (locked && sceneManager.hasHouseKeys)
        {
            subtitles.newText = openedSubtitle;
            source.PlayOneShot(openedClip);
            locked = false;
        }
        else if (locked && !sceneManager.hasHouseKeys)
        {
            subtitles.newText = lockedSubtitle;
            source.PlayOneShot(lockedClip);
        }

    }

    public void playSound()
    {

    }


}
