using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventPickupObject : MonoBehaviour, IActivateable
{

    public AudioSource source;
    public string subtitle;
    Subtitles subtitles;
    
    public bool doorKeyObject;
    public bool coffeeObject;
    public bool teaObject;

    public bool moneyObject;
    public bool skatesObject;
    public bool umbrellaObject;
    public bool bagelObject;

    private eventInventory inventory;

    public bool hasActivated { get; set; }


    private void Awake()
    {
        inventory = GameObject.Find("Scene Manager").GetComponent<eventInventory>();
    }


    public void activate()
    {
        if (!hasActivated)
        {
            subtitles = GameObject.Find("Subtitles").GetComponent<Subtitles>();
            subtitles.newText = subtitle;
            playSound();

            if (doorKeyObject) inventory.doorKey = true;
            if (coffeeObject) inventory.hasDrankCoffee = true;
            if (teaObject) inventory.hasDrankTea = true;
            if (moneyObject) inventory.hasMoney = true;
            if (skatesObject) inventory.hasSkates = true;
            if (umbrellaObject) inventory.hasUmbrella = true;
            if (bagelObject) inventory.hasBagel = true;

            GetComponent<SpriteRenderer>().enabled = false;
            hasActivated = true;
        }
    }

    public void playSound()
    {
        source.Stop();
        source.Play();
    }
}
