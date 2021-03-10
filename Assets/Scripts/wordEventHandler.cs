using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wordEventHandler : MonoBehaviour
{
    public SOwordBank bankOfWords;

    public InputField playerInput;

    private void Update()
    {
        detectPlayerInput();
    }

    void detectPlayerInput() 
    {
        if (Input.GetKeyDown(KeyCode.Return)) compareInputToWordBank(playerInput.text);
    }

    void compareInputToWordBank(string playerInput) 
    {
        for (int i = 0; i < bankOfWords.listOfWords.Count; i++)
        {
            if (bankOfWords.listOfWords[i].word == playerInput) 
            {
                if (bankOfWords.listOfWords[i].wordScriptObject.GetComponent<IActivateable>() != null) bankOfWords.listOfWords[i].wordScriptObject.GetComponent<IActivateable>().activate();
            }
        }
    }
}
