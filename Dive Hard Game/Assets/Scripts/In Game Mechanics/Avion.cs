using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UberAudio;

public class Avion : ObjectsParents
{
    [SerializeField]
    float cantidadFrenar = 2;

   

    protected override void Action() //comportamiento pasivo
    {
        //Aqui sonido del engine del Avion???
        //AudioManager.Instance.Play("PlaneSound");

    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
        
            Rigidbody2D rb = _jugador.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2((rb.velocity.x / cantidadFrenar), 0);
        //Aqui un sonido de choque con avion
        AudioManager.Instance.Play("MetalHit");
            //animación del choque con avion
        
        yield return null;
    }
}
