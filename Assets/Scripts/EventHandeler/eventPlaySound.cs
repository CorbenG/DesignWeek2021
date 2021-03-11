using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventPlaySound : MonoBehaviour, IActivateable
{

    public AudioSource source;
    public string subtitle;
    Subtitles subtitles;
    public bool houseKey = false;
    public bool coffeeCup = false;
    public bool teaBox = false;

    public bool hasActivated { get; set; }

    public void activate()
    {
        if (!hasActivated) 
        {
            subtitles = GameObject.Find("Subtitles").GetComponent<Subtitles>();
            subtitles.newText = subtitle;
            source.PlayOneShot(source.clip);
            hasActivated = true;
            if (houseKey)
            {
                SceneManager sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
                sceneManager.hasHouseKeys = true;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (coffeeCup)
            {
                SceneManager sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
                sceneManager.hasDrankCoffee = true;
            }
        }
    }

    public void playSound()
    {
        
        source.Stop();
        source.Play();
    }

    
}
