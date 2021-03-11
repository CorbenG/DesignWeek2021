using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IActivateable))]
public class eventHandler : MonoBehaviour
{
    public float interactableRange;
    public bool playerInRange;

    private IActivateable activateable;

    private GameObject player;
    private playerInput _input;


    private void Awake()
    {
        player = GameObject.Find("Player");
        _input = player.GetComponent<playerInput>();
    }

    private void Update()
    {
        detectPlayerRange();
    }

    void detectPlayerRange() 
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= interactableRange) 
        {
            playerInRange = true;
        }
    }

    void detectPlayerInput() 
    {
        if (playerInRange && _input.interact) activateable.activate();
    }
}
