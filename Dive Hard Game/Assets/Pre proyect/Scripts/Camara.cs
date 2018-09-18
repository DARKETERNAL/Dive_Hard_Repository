using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

	public Rigidbody2D cuerpo;
	Vector3 posCuerpo;
	// Use this for initialization
	void Start () {
		if (cuerpo == null)
			cuerpo = GameObject.Find("Player").GetComponent<Rigidbody2D>(); 
	}
	
	// Update is called once per frame
	void Update () {
		posCuerpo = new Vector3(cuerpo.transform.position.x,cuerpo.transform.position.y,-Mathf.Clamp(((Mathf.Abs(cuerpo.velocity.y) + Mathf.Abs(cuerpo.velocity.x))/5f),30,80));
		transform.position = Vector3.MoveTowards(transform.position, posCuerpo, 10);
	}
}
