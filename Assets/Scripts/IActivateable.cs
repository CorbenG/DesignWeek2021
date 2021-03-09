using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivateable
{
    string wordName { get; set; }

    void activate();

}
