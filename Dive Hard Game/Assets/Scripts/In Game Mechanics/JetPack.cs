using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : PassiveMechanics
{
	public float intencidad;
	float iteraciones = 30;
	public float duracion;

    protected override void Execution()//start
    {
		StartCoroutine(Impulse());
    }

	IEnumerator  Impulse()
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		for (int i = 0; i < iteraciones; i++)
		{
			rb.AddForce(new Vector2(0,-1) * intencidad / iteraciones * 10 , ForceMode2D.Impulse);
			yield return new WaitForSeconds(duracion / iteraciones);
		}
		GetComponent<JetPack>().enabled = false;
	}
}
