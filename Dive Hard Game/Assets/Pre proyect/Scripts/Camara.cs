using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

	public Transform cuerpo;
	Vector3 posCuerpo;
	// Use this for initialization
	void Start () {
		if (cuerpo == null)
			cuerpo = GameObject.Find("Player").GetComponent<Transform>(); 
	}
	
	// Update is called once per frame
	void Update () {
		posCuerpo = new Vector3(cuerpo.position.x,cuerpo.position.y,-1);
		transform.position = Vector3.MoveTowards(transform.position, posCuerpo, 10);
	}
}
