using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{

    public MundoConTienda[] poolGood;
    public MundoSinTienda[] poolBad;
    public int maxProbG, maxProbB;

    // Use this for initialization
    void Awake()
    {

        MundoConTienda[] tempPoolGood = Resources.LoadAll<MundoConTienda>("Prefabs");
        MundoSinTienda[] tempPoolBad = Resources.LoadAll<MundoSinTienda>("Prefabs");

        poolGood = new MundoConTienda[tempPoolGood.Length * 3];
        for (int i = 0; i < poolGood.Length; i += tempPoolGood.Length)
        {
            for (int j = 0; j < tempPoolGood.Length; j++)
            {
                poolGood[i + j] = Instantiate(tempPoolGood[j], new Vector3(-500, -500, 0), Quaternion.identity);
                poolGood[i + j].pobRange = new Vector2(maxProbG, maxProbG + poolGood[i + j].Probability - 1);
                maxProbG += poolGood[i + j].Probability;
            }
        }
        poolBad = new MundoSinTienda[tempPoolBad.Length * 3];
        for (int i = 0; i < poolBad.Length; i += tempPoolBad.Length)
        {
            for (int j = 0; j < tempPoolBad.Length; j++)
            {
                poolBad[i + j] = Instantiate(tempPoolBad[j], new Vector3(-500, -500, 0), Quaternion.identity);
                poolBad[i + j].pobRange = new Vector2(maxProbB,maxProbB + poolBad[i + j].Probability - 1);
                maxProbB += poolBad[i + j].Probability;
            }
        }
    }
}
