using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpeedCounter : MonoBehaviour {

	public Rigidbody2D mRig;
	public Text mText;

	// Use this for initialization
	void Start () {
		mText.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		mText.text = (Mathf.Abs((int)mRig.velocity.y * -1)).ToString();
	}
}
