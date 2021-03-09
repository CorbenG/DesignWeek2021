using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Word Bank"))]
public class SOwordBank : ScriptableObject
{
    public IActivateable[] listOfWords;
}
