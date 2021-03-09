using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public InputField input;

    public SpriteRenderer background;
    public Color rainColor;
    public Color sunColor;
    public Color snowColor;
    public Color noColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(input.textComponent.text);

        if(input.textComponent.text.ToLower() == "rain")
        {
            background.color = rainColor;
        }
        else if (input.textComponent.text.ToLower() == "sun")
        {
            background.color = sunColor;
        }
        else if (input.textComponent.text.ToLower() == "snow")
        {
            background.color = snowColor;
        }
        else
        {
            background.color = noColor;
        }
    }
}
