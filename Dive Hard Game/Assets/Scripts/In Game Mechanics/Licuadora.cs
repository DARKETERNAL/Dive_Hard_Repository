using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Licuadora : MundoConTienda {

    protected override void Action() //comportamiento pasivo
    {

    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
        yield return null;
    }
}
