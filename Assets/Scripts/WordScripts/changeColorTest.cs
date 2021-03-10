using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeColorTest : MonoBehaviour, IActivateable
{
    public Color backgroundColor;

    public Image background;

    private void Start()
    {
        
    }

    public void activate()
    {
        background = GameObject.Find("Background").GetComponent<Image>();
        background.color = backgroundColor;
    }

    public void playSound()
    {
        throw new System.NotImplementedException();
    }
}
