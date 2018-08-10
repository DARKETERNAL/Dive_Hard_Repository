using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton _instance;
    public static int[] storeLevels = new int[2];//se puede cambiar
    // Use this for initialization
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }      
        else
            Destroy(transform.gameObject);
    }
}
