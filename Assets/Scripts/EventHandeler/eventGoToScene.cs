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

    private eventInventory inventory;

    public bool hasActivated { get; set; }

    private void Awake()
    {
        inventory = GameObject.Find("Scene Manager").GetComponent<eventInventory>();
    }

    public void activate()
    {
        subtitles = GameObject.Find("Subtitles").GetComponent<Subtitles>();
        sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
        if (!locked)
        {
            sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
            sceneManager.currentScene.GetComponent<Room>().GoToRoom("Interact");
        }
        else if (locked && inventory.doorKey)
        {
            subtitles.newText = openedSubtitle;
            source.PlayOneShot(openedClip);
            locked = false;
        }
        else if (locked && !inventory.doorKey)
        {
            subtitles.newText = lockedSubtitle;
            source.PlayOneShot(lockedClip);
        }

    }

    public void playSound()
    {

    }


}
