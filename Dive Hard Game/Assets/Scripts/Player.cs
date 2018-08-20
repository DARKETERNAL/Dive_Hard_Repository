using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class Player : MonoBehaviour
{
    float venenoTime = 0;
    public float venenoMult = 1;
=======
public class Player : MonoBehaviour {
>>>>>>> origin/master

    private void Update()
    {
        if (venenoTime>0)
        {
            venenoTime -= Time.deltaTime;
        }
        else
        {
            venenoMult = 1;
        }
    }

    public void Poison(float poisonTime, float poisonMult)
    {
        venenoTime += poisonTime;
        if (poisonMult<venenoMult)
        {
            venenoMult = poisonMult;
        }
    }
}
