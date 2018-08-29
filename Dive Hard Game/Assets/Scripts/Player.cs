using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    public TextMeshProUGUI bloodText;

    public float bloodInGame = 0;

    float venenoTime = 0;
    public float venenoMult = 1;

    [Header("La sangre que da cada uno")]
    public int bloodBag;
    public int licuadora;
    public int meteoros;
    public int paloma;
    public int swipe;



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

        bloodText.text = "Blood: " + Mathf.Round(bloodInGame);
    }

    public void Poison(float poisonTime, float poisonMult)
    {
        venenoTime += poisonTime;
        if (poisonMult < venenoMult)
        {
            venenoMult = poisonMult;
        }
    }
}
