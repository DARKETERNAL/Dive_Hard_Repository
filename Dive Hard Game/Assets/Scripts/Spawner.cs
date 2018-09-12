using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region variables
    Pooling mPools;
    bool badBool = true, goodBool = true;
    [SerializeField]
    Rigidbody2D target;
    Vector3 GV, BV;
    [SerializeField]
    float tG = .5f, tB = 1f;
    MundoConTienda selectedG;
    MundoConTienda[] aspirantG = new MundoConTienda[4];
    MundoSinTienda selectedB;
    MundoSinTienda[] aspirantB = new MundoSinTienda[4];
    #endregion

    void Start()
    {

        mPools = GetComponent<Pooling>();

    }

    void FixedUpdate()
    {
        if (Mathf.Abs(target.velocity.x) > 40 || Mathf.Abs(target.velocity.y) > 40)
        {
            if (goodBool)
                StartCoroutine(GoodS());

            if (badBool)
                StartCoroutine(BadS());
        }
    }

    #region G
    int SelectorG(int r)
    {
        for (int i = 0; i < mPools.poolGood.Length; i++)
        {
            if (!(mPools.poolGood[i].pobRange.y - mPools.poolGood[i].pobRange.x < 0))
            {
                if (r >= mPools.poolGood[i].pobRange.x && r <= mPools.poolGood[i].pobRange.y)
                {
                    if (!mPools.poolGood[i].active)
                    {
                        return i;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }
        return 3;
    }
    IEnumerator GoodS()
    {
        int k, s;
        goodBool = false;

        for (int i = 0; i < aspirantG.Length; i++)
        {
            k = Random.Range(0, mPools.maxProbG);
            s = SelectorG(k);
            
            if ((s < 0)) { goodBool = true; yield break; }

            aspirantG[i] = mPools.poolGood[s];

            yield return new WaitForSeconds(0.01f);
        }

        Vector2 acI = target.velocity;
        yield return new WaitForSeconds(0.1f);
        Vector2 acF = target.velocity;
        GV = target.transform.position + new Vector3((acF.x * tG) + ((acF.x - acI.x) * (tG) * (tG)) / 2, (acF.y * tG) + ((acF.y - acI.y) * (tG) * (tG)) / 2, 0);
        if (GV.y <= 20) { goodBool = true; yield break; }

        selectedG = null;


        for (int i = 0; i < aspirantG.Length; i++)
        {
            if (selectedG == null)
                selectedG = aspirantG[i];

            if ((-(((GV.y - selectedG.height) * (GV.y - selectedG.height)) * selectedG.inverseRange) + 3) < (-(((GV.y - aspirantG[i].height) * (GV.y - aspirantG[i].height)) * aspirantG[i].inverseRange) + 3))
                if (!aspirantG[i].active)
                    selectedG = aspirantG[i];


            yield return new WaitForSeconds(0.01f);
        }

        if (((-(((GV.y - selectedG.height) * (GV.y - selectedG.height)) * selectedG.inverseRange) + 3) <= 0))
        {
            goodBool = true;
            yield break;
        }
        yield return new WaitForSeconds(0.8f);
        //posible correccion de offsets
        selectedG.transform.position = GV + selectedG.offSet + new Vector3(-target.velocity.x * .98f, 0, 0);
        selectedG.selfR.simulated = true;
        selectedG.selfR.velocity = new Vector2(target.velocity.x * 0.98f, 0);
        selectedG.active = true;
        goodBool = true;
        yield return null;
    }
    #endregion

    #region B
    int SelectorB(int r)
    {
        for (int i = 0; i < mPools.poolBad.Length; i++)
        {
            if (!(mPools.poolBad[i].pobRange.y - mPools.poolBad[i].pobRange.x < 0))
            {
                if (r >= mPools.poolBad[i].pobRange.x && r <= mPools.poolBad[i].pobRange.y)
                {
                    if (!mPools.poolBad[i].active)
                    {
                        return i;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }
        return 3;
    }
    IEnumerator BadS()
    {
        int k, s;
        badBool = false;
        Vector2 acI = target.velocity;
        yield return new WaitForSeconds(0.1f);
        Vector2 acF = target.velocity;
        BV = target.transform.position + new Vector3((acF.x * tB) + ((acF.x - acI.x) * (tB) * (tB)) / 2, (acF.y * tB) + ((acF.y - acI.y) * (tB) * (tB)) / 2, 0);
        if (BV.y <= 20) { badBool = true; yield break; }

        selectedB = null;
        for (int i = 0; i < aspirantB.Length; i++)
        {
            k = Random.Range(0, mPools.maxProbB);
            s = SelectorB(k);

            if ((s < 0)) { badBool = true; yield break; }

            aspirantB[i] = mPools.poolBad[s];

            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < aspirantB.Length; i++)
        {
            if (selectedB == null)
                selectedB = aspirantB[i];

            if ((-(((BV.y - selectedB.height) * (BV.y - selectedB.height)) * selectedB.inverseRange) + 3) < (-(((BV.y - aspirantB[i].height) * (BV.y - aspirantB[i].height)) * aspirantB[i].inverseRange) + 3))
                if (!aspirantB[i].active)
                    selectedB = aspirantB[i];


            yield return new WaitForSeconds(0.01f);
        }

        if (((-(((BV.y - selectedB.height) * (BV.y - selectedB.height)) * selectedB.inverseRange) + 3) <= 0))
        {
            badBool = true;
            yield break;
        }
        yield return new WaitForSeconds(0.8f);
        //posible correccion de offsets
        selectedB.transform.position = BV + selectedB.offSet + new Vector3(-target.velocity.x * .98f, 0, 0);
        selectedB.selfR.simulated = true;
        selectedB.selfR.velocity = new Vector2(target.velocity.x * 0.98f, 0);
        selectedB.active = true;
        badBool = true;
        yield return null;
    }
    #endregion
}
