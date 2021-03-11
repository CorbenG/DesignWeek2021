﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventPlaySound : MonoBehaviour, IActivateable
{

    public AudioSource source;

    public bool hasActivated { get; set; }

    public void activate()
    {
        Debug.Log("Activate!");
        if(!hasActivated)
            playSound();
    }

    public void playSound()
    {
        source.Stop();
        source.Play();
    }
}
