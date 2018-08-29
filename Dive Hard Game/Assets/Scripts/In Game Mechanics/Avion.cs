using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avion : MundoConTienda
{
    [SerializeField]
    float cantidadFrenar = 2;

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
            rb.velocity = new Vector2((rb.velocity.x / cantidadFrenar), 0);
            //Aqui un sonido de choque con avion
            //animación del choque con avion
            lim++;
        }
        yield return null;
    }
}
