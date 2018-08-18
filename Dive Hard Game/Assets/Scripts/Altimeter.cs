using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Altimeter : MonoBehaviour {


    RectTransform altimeterFace;
    Transform playerTransform;
    TextMeshProUGUI altimeterText;
    float currentAltitude;

    

	// Use this for initialization
	void Start () {

        altimeterFace = GetComponent<RectTransform>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        altimeterText = GetComponentInChildren<TextMeshProUGUI>();

        altimeterFace.localPosition = new Vector3(0, (playerTransform.position.y / 5) , 0);

    }
	
	// Update is called once per frame
	void Update () {
        float t = Time.deltaTime;

        altimeterFace.localPosition = new Vector3(0, playerTransform.position.y / 5 , 0);
        currentAltitude = Mathf.Round(playerTransform.localPosition.y);
        altimeterText.text = string.Format("{0}m ----", currentAltitude.ToString());  
	}
}
