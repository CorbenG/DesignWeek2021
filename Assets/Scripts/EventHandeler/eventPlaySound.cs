using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventPlaySound : MonoBehaviour, IActivateable
{

    public AudioSource source;
    public string subtitle;
    Subtitles subtitles;

    public bool hasActivated { get; set; }

    public void activate()
    {
        if (!hasActivated) 
        {
            subtitles = GameObject.Find("Subtitles").GetComponent<Subtitles>();
            subtitles.newText = subtitle;
            playSound();
            hasActivated = true;
        }
    }

    public void playSound()
    {
        
        source.Stop();
        source.Play();
    }

    
}
