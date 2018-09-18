using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avion : ObjectsParents
{
    [SerializeField]
    float cantidadFrenar = 2;

   

    protected override void Action() //comportamiento pasivo
    {
       
    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
        
            Rigidbody2D rb = _jugador.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2((rb.velocity.x / cantidadFrenar), 0);
            //Aqui un sonido de choque con avion
            //animación del choque con avion
        
        yield return null;
    }
}
