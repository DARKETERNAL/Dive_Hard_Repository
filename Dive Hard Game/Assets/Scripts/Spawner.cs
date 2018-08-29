using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Pooling mPools;
    bool badBool = true, goodBool = true;
    [SerializeField]
    Rigidbody2D target;
    Vector3 GV, BV;
    [SerializeField]
    float tG = 2, tB = 2.5f;
    MundoConTienda selectedG;
    MundoConTienda[] aspirantG = new MundoConTienda[4];
    MundoSinTienda selectedB;
    MundoSinTienda[] aspirantB = new MundoSinTienda[4];


    // Use this for initialization
    void Start()
    {

        mPools = GetComponent<Pooling>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Abs(target.velocity.y) > 20)
        {
            if (goodBool)
                StartCoroutine(GoodS());

            if (badBool)
                StartCoroutine(BadS());
        }

    }
    IEnumerator GoodS()
    {
        goodBool = false;
        Vector2 acI = target.velocity;
        yield return new WaitForSeconds(0.1f);
        Vector2 acF = target.velocity;
        GV = target.transform.position + new Vector3((acF.x * tG) + ((acF.x - acI.x) * (tG) * (tG)) / 2, (acF.y * tG) + ((acF.y - acI.y) * (tG) * (tG)) / 2, 0);

        selectedG = null;
        for (int i = 0; i < aspirantG.Length; i++)
        {
            int k = Random.Range(0, mPools.poolGood.Length);
            aspirantG[i] = mPools.poolGood[k];
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < aspirantG.Length; i++)
        {
            if (selectedG == null)
                selectedG = aspirantG[i];

            if ((-(((GV.y - selectedG.height) * (GV.y - selectedG.height)) * selectedG.inverseRange) + 3 * (selectedG.Probability / 100f)) < (-(((GV.y - aspirantG[i].height) * (GV.y - aspirantG[i].height)) * aspirantG[i].inverseRange) + 3 * (aspirantG[i].Probability / 100)))
                if (!aspirantG[i].active)
                    selectedG = aspirantG[i];

            yield return new WaitForSeconds(0.01f);
        }

        if (((-(((GV.y - selectedG.height) * (GV.y - selectedG.height)) * selectedG.inverseRange) + 3 * (selectedG.Probability / 100)) <= 0) || (selectedG.active) || (GV.y <= 0))
        {
            goodBool = true;
            yield break;
        }
        yield return new WaitForSeconds(0.8f);
        //posible correccion de offsets
        selectedG.transform.position = GV + selectedG.offSet;

        selectedG.active = true;
        goodBool = true;
        yield return null;
    }
    IEnumerator BadS()
    {
        badBool = false;
        Vector2 acI = target.velocity;
        yield return new WaitForSeconds(0.1f);
        Vector2 acF = target.velocity;
        BV = target.transform.position + new Vector3((acF.x * tB) + ((acF.x - acI.x) * (tB) * (tB)) / 2, (acF.y * tB) + ((acF.y - acI.y) * (tB) * (tB)) / 2, 0);

        selectedB = null;
        for (int i = 0; i < aspirantB.Length; i++)
        {
            int k = Random.Range(0, mPools.poolBad.Length);
            aspirantB[i] = mPools.poolBad[k];
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < aspirantB.Length; i++)
        {
            if (selectedB == null)
                selectedB = aspirantB[i];

            if ((-(((BV.y - selectedB.height) * (BV.y - selectedB.height)) * selectedB.inverseRange) + 3 * (selectedB.Probability / 100)) < (-(((BV.y - aspirantB[i].height) * (BV.y - aspirantB[i].height)) * aspirantB[i].inverseRange) + 3 * (aspirantB[i].Probability / 100)))
                if (!aspirantB[i].active)
                    selectedB = aspirantB[i];


            yield return new WaitForSeconds(0.01f);
        }

        if (((-(((BV.y - selectedB.height) * (BV.y - selectedB.height)) * selectedB.inverseRange) + 3 * (selectedB.Probability / 100)) <= 0) || (selectedB.active) || (BV.y <= 0))
        {
            badBool = true;
            yield break;
        }
        yield return new WaitForSeconds(0.8f);
        //posible correccion de offsets
        selectedB.transform.position = BV + selectedB.offSet;

        selectedB.active = true;
        badBool = true;
        yield return null;
    }
}
