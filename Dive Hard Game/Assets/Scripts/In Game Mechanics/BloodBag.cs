using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UberAudio;

public class BloodBag : MundoSinTienda {

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
            _jugador.bloodInGame += (_jugador.bloodBag * _jugador.venenoMult);
            lim++;
            AudioManager.Instance.Play("Bloodbag");
            BackToPool();
        }
        yield return null;
    }
}
