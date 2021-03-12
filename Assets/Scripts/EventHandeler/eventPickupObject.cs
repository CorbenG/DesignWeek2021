using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventPickupObject : MonoBehaviour, IActivateable
{

    public AudioSource source;
    public string subtitle;
    Subtitles subtitles;

    public bool hideSprite;

    [Header("What Object is this on?")]
    public bool doorKeyObject;
    public bool coffeeObject;
    public bool teaObject;

    public bool moneyObject;
    public bool bagelObject;
    public bool hotDogObject;
    public bool crownObject;

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
            if (bagelObject) inventory.hasBagel = true;
            if (crownObject) inventory.hasCrown = true;
            if (hotDogObject) inventory.hasHotdog = true;

            setTransform();

            if (hideSprite) GetComponent<SpriteRenderer>().enabled = false;
            
            hasActivated = true;
        }
    }

    public void playSound()
    {
        source.Stop();
        source.Play();
    }

    void setTransform() 
    {
        if (inventory.doorKey && doorKeyObject)
        {
            transform.parent = GameObject.Find("keyPos").transform;
            GetComponent<SpriteRenderer>().sortingOrder = 5;
            gameObject.transform.position = GameObject.Find("keyPos").transform.position;
        }

        if (inventory.hasDrankCoffee && coffeeObject)
        {
            transform.parent = GameObject.Find("mugPos").transform;
            GetComponent<SpriteRenderer>().sortingOrder = 5;
            gameObject.transform.position = GameObject.Find("mugPos").transform.position;
        }

        if (inventory.hasMoney && moneyObject)
        {
            transform.parent = GameObject.Find("moneyPos").transform;
            GetComponent<SpriteRenderer>().sortingOrder = 5;
            gameObject.transform.position = GameObject.Find("moneyPos").transform.position;
        }

        if (inventory.hasBagel && bagelObject)
        {
            transform.parent = GameObject.Find("bagelPos").transform;
            GetComponent<SpriteRenderer>().sortingOrder = 5;
            gameObject.transform.position = GameObject.Find("bagelPos").transform.position;
        }

        if (inventory.hasCrown && crownObject)
        {
            transform.parent = GameObject.Find("crownPos").transform;
            GetComponent<SpriteRenderer>().sortingOrder = 5;
            gameObject.transform.position = GameObject.Find("crownPos").transform.position;
        }

        if (inventory.hasHotdog && hotDogObject)
        {
            transform.parent = GameObject.Find("hotDogPos").transform;
            GetComponent<SpriteRenderer>().sortingOrder = 5;
            gameObject.transform.position = GameObject.Find("hotDogPos").transform.position;
        }

    }
}
