using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UberAudio;

public class Paloma : ConTienda
{
	[SerializeField]
	float cantidadAcelerar = 1.2f;
   
	protected override void Action() //comportamiento pasivo
    {
      
    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
        
            _jugador.bloodInGame += (_jugador.paloma * _jugador.venenoMult);
            Rigidbody2D rb = _jugador.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Abs(rb.velocity.y * cantidadAcelerar));




        //Aqui un sonido de paloma muriendo
        AudioManager.Instance.Play("PigeonDeath");

		yield return null;
	}
}
