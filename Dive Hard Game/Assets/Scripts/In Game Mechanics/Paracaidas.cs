using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paracaidas : MundoConTienda
{
    [SerializeField]
    float cantidadFrenar = 2;

    protected override void Action() //comportamiento pasivo
    {

    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
        Rigidbody2D rb = _jugador.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2((rb.velocity.x / cantidadFrenar), Mathf.Abs(rb.velocity.y / cantidadFrenar));
        Destroy(GetComponent<Paracaidas>());
        //Aqui un sonido de rebote en paracaidas
        //animación del rebote en paracaidas
        yield return null;
    }
}
