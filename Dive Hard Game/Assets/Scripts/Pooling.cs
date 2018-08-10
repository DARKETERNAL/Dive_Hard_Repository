using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour {
    [SerializeField]
    int[] good = new int[3], bad = new int[4];
    InGameGoodObjects[] poolGood;
    InGameBadObjects[] poolBad;
	// Use this for initialization
	void Start () {
		
	}
}
