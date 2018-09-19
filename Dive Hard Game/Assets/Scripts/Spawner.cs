using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region variables
    Pooling mPools;
    bool Bool = true;
    [SerializeField]
    Rigidbody2D target;
    Vector3 V;
    [SerializeField]
    float t = 3f;
    ObjectsParents selected;
    ObjectsParents[] aspirant = new ObjectsParents[4];
    #endregion

    void Start()
    {
        mPools = GetComponent<Pooling>();

    }

    void FixedUpdate()
    {
        if (/*Mathf.Abs(target.velocity.x) > 40 ||*/ Mathf.Abs(target.velocity.y) > 20)
        {          
            if (Bool)
            { 
                StartCoroutine(Spw());
            }
        }
        
    }

    #region Spawner
    int SelectorB(int r)
    {
        for (int i = 0; i < mPools.pool.Length; i++)
        {
            if (!(mPools.pool[i].pobRange.y - mPools.pool[i].pobRange.x < 0))
            {
                if (r >= mPools.pool[i].pobRange.x && r <= mPools.pool[i].pobRange.y)
                {
                    return i;
                }
            }
        }
        return -1;
    }
    IEnumerator Spw()
    {
        int k, s, d = 0;
        Bool = false;
        Vector2 acI = target.velocity;
        yield return new WaitForSeconds(0.1f);
        Vector2 acF = target.velocity;
        V = target.transform.position + new Vector3((acF.x * t) + ((acF.x - acI.x) * (t) * (t)) / 2, (acF.y * t) + ((acF.y - acI.y) * (t) * (t)) / 2, 0);
        if (V.y <= 20) { Bool = true; yield break; }

        selected = null;
        for (int i = 0; i < aspirant.Length; i++)
        {
          
            k = Random.Range(0, mPools.maxProb);

            s = SelectorB(k);

            if (s < 0) { d = s; break; }
            aspirant[i] = mPools.pool[s];

            yield return new WaitForSeconds(0.01f);
        }
        if (d < 0) { Bool = true; yield break; }
        for (int i = 0; i < aspirant.Length; i++)
        {

            if (!aspirant[i].active)
            {
                if (selected == null)
                    selected = aspirant[i];

                if ((-(((V.y - selected.height) * (V.y - selected.height)) * selected.inverseRange) + 3) < (-(((V.y - aspirant[i].height) * (V.y - aspirant[i].height)) * aspirant[i].inverseRange) + 3))
                    if (!aspirant[i].active)
                        selected = aspirant[i];


                yield return new WaitForSeconds(0.01f);
            }

        }

        if (selected == null || ((-(((V.y - selected.height) * (V.y - selected.height)) * selected.inverseRange) + 3) <= 0))
        {
            Bool = true;
            yield break;
        }
        yield return new WaitForSeconds(0.01f);
        if (Vector3.Distance(target.transform.position, V) < (Camera.main.transform.position.z / -2f) + 10) { Bool = true; yield break; }
       
        //posible correccion de offsets
        selected.transform.position = V + selected.offSet + new Vector3(-target.velocity.x * .87f / 1f, 0, 0);
        selected.selfR.simulated = true;
        selected.selfR.velocity = new Vector2(target.velocity.x * 0.99f, 0);
        selected.active = true;
        Bool = true;
        yield return null;
    }
    #endregion
}
