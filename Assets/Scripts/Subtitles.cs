using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subtitles : MonoBehaviour
{
    public string instructions = "To use this script, just link it to a text UI object, then, when you want to pass in new text, just change the newText string from this script from another script." +
        "This script will detect the change and print out the text.";
    public float textSpeed = 0.005f;
    public string newText = " ";
    public Text text;
    string currentText = " ";

    int letterIndex = 0;

    string prevText = " ";

    float nextLetterCounter;

    float loadTimeOffset;

    // Start is called before the first frame update
    void Start()
    {
        loadTimeOffset = Time.time;
        nextLetterCounter = 0;
        text.text = newText;
    }

    // Update is called once per frame
    void Update()
    {
        //Update first frame new text is called
        if(prevText != newText)
        {
            letterIndex = 0;
            nextLetterCounter = currentTime();
            currentText = " ";
        }
        prevText = newText;
        if (newText != text.text)
        {
            if (currentTime() >= nextLetterCounter && newText.Length > 0 && letterIndex < newText.Length)
            {
                currentText = currentText + newText[letterIndex];
                if(letterIndex < newText.Length)
                    letterIndex++;
                nextLetterCounter = currentTime() + textSpeed;
            }
        }
        text.text = currentText;
    }

    float currentTime()
    {
        return Time.time - loadTimeOffset;
    }
}
