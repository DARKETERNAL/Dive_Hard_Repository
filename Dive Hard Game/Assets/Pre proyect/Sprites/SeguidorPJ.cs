using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguidorPJ : MonoBehaviour {

	public Transform cuerpo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3( cuerpo.position.x,transform.position.y,transform.position.z);
	}
}
