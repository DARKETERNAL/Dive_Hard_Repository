using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntero : MonoBehaviour {

    public RectTransform centroPersonaje;
    RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update () {
        rect.LookAt(centroPersonaje,Vector3.up);
	}
}
