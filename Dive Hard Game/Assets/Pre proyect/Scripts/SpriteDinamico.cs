using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDinamico : MonoBehaviour {

	public Sprite[] sprites;
	Rigidbody2D rig;
	//PolygonCollider2D collider;
	SpriteRenderer sprRenderer;

	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D>();
		sprRenderer = GetComponent<SpriteRenderer>();
		//collider = GetComponent<PolygonCollider2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(rig.velocity.y  < 0)
		{
			sprRenderer.sprite = sprites[1];

		}
		else
			sprRenderer.sprite = sprites[0];
	}
}
