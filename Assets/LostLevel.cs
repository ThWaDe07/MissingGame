using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LostLevel : MonoBehaviour
{
    public float timeRemaining = 3;
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        } else { Application.Quit(); }
    }
}
