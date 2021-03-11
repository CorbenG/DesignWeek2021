using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivateable
{
    bool hasActivated { get; set; }

    void activate();

    void playSound();

}