using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBag : MundoSinTienda {


    protected override void Action() //comportamiento pasivo
    {

    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
        _jugador.bloodInGame += (_jugador.bloodBag * _jugador.venenoMult);
        yield return null;
    }
}
