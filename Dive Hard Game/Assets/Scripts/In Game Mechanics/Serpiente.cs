using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serpiente : MundoConTienda
{
    [SerializeField]
    float poisonTime = 10;
    [SerializeField]
    float poisonMult = 0.5f;

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
            _jugador.Poison(poisonTime, poisonMult);
            //Aqui un sonido de envenenamiento
            //animación del choque con serpiente
            lim++;
        }
        yield return null;
    }
}
