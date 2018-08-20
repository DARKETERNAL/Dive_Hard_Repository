using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paloma : MundoConTienda
{
	[SerializeField]
	float cantidadAcelerar = 2;
    int lim = 0;
    bool activeDelta;
	protected override void Action() //comportamiento pasivo
    {
        if (activeDelta != active)
        {
            lim = 0;
        }
        activeDelta = active;
    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
        if (lim == 0)
        {
            Rigidbody2D rb = _jugador.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Abs(rb.velocity.y * cantidadAcelerar));
            lim++;
        }
		

		//Aqui un sonido de paloma muriendo
		yield return null;
	}
}
