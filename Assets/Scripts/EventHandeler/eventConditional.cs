using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventConditional : MonoBehaviour, IActivateable
{
    public AudioSource source;
    public AudioClip[] clips;
    public string[] subtitle;
    Subtitles subtitles;

    public bool hotDogObject;
    public bool bagelObject;

    private eventInventory inventory;

    public bool hasActivated { get; set; }

    private void Awake()
    {
        inventory = GameObject.Find("Scene Manager").GetComponent<eventInventory>();
    }

    public void activate()
    {
        playSound();
    }

    public void playSound()
    {
        //they dont have money and havent bought anything
        if (!inventory.hasHotdog && !inventory.hasMoney || !inventory.hasBagel && !inventory.hasMoney) 
        {
            source.clip = clips[0];
            source.Play();
        }

        if (!inventory.hasHotdog && inventory.hasMoney || !inventory.hasBagel && inventory.hasMoney) 
        {
            source.clip = clips[1];
            source.Play();

            if (hotDogObject) inventory.hasHotdog = true;
            if (bagelObject) inventory.hasBagel = true;

            if (!bagelObject && !hotDogObject) Debug.LogError("No object selected for: " + gameObject.name);
        }

        if (inventory.hasHotdog && inventory.hasMoney || inventory.hasBagel && inventory.hasMoney)
        {
            source.clip = clips[3];
            source.Play();
            hasActivated = true;
        }

    }
}
