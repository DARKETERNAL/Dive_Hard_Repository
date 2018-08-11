using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorito : InGameGoodObjects {

	[SerializeField]
	float amount = 2;
	float iteracion = 8;
	float speed = 8;
	bool move = true;
	Rigidbody2D rb;
	protected override void Action() //comportamiento pasivo
    {
		if(move)
			transform.position += new Vector3(1, -1,0) * speed * Time.deltaTime;
	}

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
		rb = _jugador.GetComponent<Rigidbody2D>();
		move = false;
		transform.parent = _jugador.gameObject.transform;
		rb.velocity = new Vector2(Mathf.Abs(rb.velocity.x), -1 * Mathf.Abs(rb.velocity.y));
		rb.velocity += new Vector2(speed/6,-speed/6);


		for (int i = 0; i < iteracion; i++)
		{
			rb.velocity *= new Vector2(speed / 10, speed / 10) * amount;
			yield return new WaitForSeconds(0.2f);
		}
		transform.parent = null;
		move = true;
		Destroy(this.gameObject,2);
		//Aqui un sonido de meteorito
		yield return null;
    }
}
