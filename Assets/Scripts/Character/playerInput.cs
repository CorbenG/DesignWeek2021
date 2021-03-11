﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour
{
    public bool interact { get; private set; }
    public bool jump { get; private set; }
    public float moveX { get; private set; }


    private void Update()
    {
        if (Input.GetButtonDown("Jump")) jump = true;

        if (Input.GetButtonDown("Interact")) interact = true;

        moveX = Input.GetAxisRaw("Horizontal");
    }
}