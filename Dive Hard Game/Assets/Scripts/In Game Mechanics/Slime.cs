using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UberAudio;

//[RequireComponent(typeof(AudioSource))]

public class Slime : ObjectsParents {

	[SerializeField]
	float cantidadFreno = 2;
   

    protected override void Action() //comportamiento pasivo
    {
      
    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
      
		    Rigidbody2D rb = _jugador.GetComponent<Rigidbody2D>();
		    rb.velocity = new Vector2(rb.velocity.x / cantidadFreno, rb.velocity.y / cantidadFreno);
            AudioManager.Instance.Play("Slime");
          
		yield return null;
    }
}
