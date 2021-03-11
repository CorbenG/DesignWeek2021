using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour
{
    [SerializeField]
    public bool interact { get; private set; }
    public bool jump { get; private set; }
    public float moveX { get; private set; }


    private void Update()
    {
        if (Input.GetButtonDown("Jump")) jump = true;
        else jump = false;

        if (Input.GetButtonDown("Interact")) interact = true;
        else interact = false;

        moveX = Input.GetAxisRaw("Horizontal");

    }
}
