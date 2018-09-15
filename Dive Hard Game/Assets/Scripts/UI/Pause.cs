using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    bool onPause;

    public void PauseButton()
    {
        if (onPause == false)
            onPause = true;
        else
            onPause = false;


        if (onPause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1; 
    }
}
