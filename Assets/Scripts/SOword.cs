using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Created Assets/Word"))]
public class SOword : ScriptableObject
{
    public string word;
    public AudioClip clip;

    public GameObject wordScriptObject;
}
