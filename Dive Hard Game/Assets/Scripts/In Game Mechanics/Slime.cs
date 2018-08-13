using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MundoSinTienda {

	[SerializeField]
	float cantidadFreno = 2;

	protected override void Action() //comportamiento pasivo
    {

    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
		Rigidbody2D rb = _jugador.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(rb.velocity.x / cantidadFreno, rb.velocity.y / cantidadFreno);
		Destroy(GetComponent<Slime>());
		//Aqui un sonido
		yield return null;
    }
}
