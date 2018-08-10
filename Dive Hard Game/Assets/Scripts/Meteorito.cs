using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorito : InGameGoodObjects {

    protected override void Action() //comportamiento pasivo
    {

    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
        yield return null;
    }
}
