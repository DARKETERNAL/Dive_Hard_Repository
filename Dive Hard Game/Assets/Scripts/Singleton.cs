using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton _instance;
    public static int[] storeLevels = new int[11];//se puede cambiar
    // Use this for initialization
    void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }      
        else
            Destroy(transform.gameObject);
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        Screen.SetResolution(1280, 720, true);
    }
}
