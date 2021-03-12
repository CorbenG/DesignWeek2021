using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventRepeatable : MonoBehaviour,IActivateable
{
    public AudioSource source;
    public AudioClip[] clips;
    public string[] subtitle;
    Subtitles subtitles;

    public int maxNumOfTimesActivated;
    public int currentNumOfTimesActivated;

    private SpriteRenderer renderer;
    public Sprite spriteToSwitchTo;

    public bool hasActivated { get; set; }

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        subtitles = GameObject.Find("Subtitles").GetComponent<Subtitles>();

    }

    public void activate()
    {
        if (!hasActivated && currentNumOfTimesActivated <= maxNumOfTimesActivated)
        {
            playSound();
            currentNumOfTimesActivated++;

            if (currentNumOfTimesActivated >= maxNumOfTimesActivated) 
            {
                renderer.sprite = spriteToSwitchTo;
                hasActivated = true;
            }
        }
    }

    public void playSound()
    {
        switch (currentNumOfTimesActivated) 
        {
            case 0:
                source.Stop();
                source.clip = clips[currentNumOfTimesActivated];
                subtitles.newText = subtitle[currentNumOfTimesActivated];
                source.Play();
                break;
            case 1:
                source.Stop();
                source.clip = clips[currentNumOfTimesActivated];
                subtitles.newText = subtitle[currentNumOfTimesActivated];
                source.Play();
                break;
            case 2:
                source.Stop();
                source.clip = clips[currentNumOfTimesActivated];
                subtitles.newText = subtitle[currentNumOfTimesActivated];
                source.Play();
                break;
            case 3:
                source.Stop();
                source.clip = clips[currentNumOfTimesActivated];
                subtitles.newText = subtitle[currentNumOfTimesActivated];
                source.Play();
                break;
            case 4:
                source.Stop();
                source.clip = clips[currentNumOfTimesActivated];
                subtitles.newText = subtitle[currentNumOfTimesActivated];
                source.Play();
                break;
            case 5:
                source.Stop();
                source.clip = clips[currentNumOfTimesActivated];
                subtitles.newText = subtitle[currentNumOfTimesActivated];
                source.Play();
                break;
        }
    }

    
}
