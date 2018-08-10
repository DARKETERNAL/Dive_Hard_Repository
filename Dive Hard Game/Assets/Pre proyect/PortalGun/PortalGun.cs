using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour {

	public GameObject portalEntrada;
	public GameObject PortalSalida;

	[SerializeField]
	int alturaDelPortal, numDisparos;

	// Use this for initialization
	void Start () {
		portalEntrada.GetComponent<Collider2D>().isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (numDisparos == 0)
		{
			portalEntrada.GetComponent<Collider2D>().isTrigger = false;
			portalEntrada.GetComponent<SeguidorPJ>().enabled = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == portalEntrada)
		{
			if (numDisparos > 0)
			{
				transform.position += new Vector3(0, alturaDelPortal, 0);
				PortalSalida.transform.position = transform.position;
				numDisparos--;
			}
		}
	}
}
