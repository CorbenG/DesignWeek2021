using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IActivateable))]
public class eventHandler : MonoBehaviour
{
    public float interactableRange;
    public bool playerInRange;

    [SerializeField]
    private IActivateable activateable;

    private GameObject player;
    private playerInput _input;

    GameObject ePopup;


    private void Awake()
    {
        player = GameObject.Find("Player");
        _input = player.GetComponent<playerInput>();
        activateable = GetComponent<IActivateable>();
        ePopup = this.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        detectPlayerRange();
        detectPlayerInput();
        Debug.Log(playerInRange);
    }

    void detectPlayerRange() 
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= interactableRange && !activateable.hasActivated)
        {
            playerInRange = true;
            ePopup.SetActive(true);
        }
        else
        {
            playerInRange = false;
            ePopup.SetActive(false);
        }
    }

    void detectPlayerInput() 
    {
        if (playerInRange && _input.interact) 
        {
            activateable.activate();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactableRange);
    }
}
