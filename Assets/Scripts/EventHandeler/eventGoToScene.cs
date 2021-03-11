using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventGoToScene : MonoBehaviour, IActivateable
{

    SceneManager sceneManager;

    public bool hasActivated { get; set; }

    public void activate()
    {
        sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
        sceneManager.currentScene.GetComponent<Room>().GoToRoom("Interact");
    }

    public void playSound()
    {

    }


}
