using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public Sprite este;
    public GameObject estex2;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 3; i++)
        {
            Vector3 pos = new Vector3(transform.position.x+(300*i), transform.position.y, transform.position.z);
            Instantiate(estex2,pos,Quaternion.identity);
        }
	}
	

}
