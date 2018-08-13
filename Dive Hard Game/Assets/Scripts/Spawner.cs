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
        if (goodBool)
            StartCoroutine(GoodS());

        if (badBool)
            StartCoroutine(BadS());
    }
    IEnumerator GoodS()
    {
        goodBool = false;
        Vector2 acI = target.velocity;
        yield return new WaitForSeconds(0.1f);
        Vector2 acF = target.velocity;
        GV = new Vector3((acI.x * tG) + ((acF.x - acI.x) * (tG) * (tG)) / 2, (acI.y * tG) + ((acF.y - acI.y) * (tG) * (tG)) / 2, 0);
        for (int i = 0; i < aspirantG.Length; i++)
        {
            aspirantG[i] = mPools.poolGood[Random.Range(0, mPools.poolGood.Length)];
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < aspirantG.Length; i++)
        {
            if (selectedG == null)
                selectedG = aspirantG[i];

            if ((-(((target.transform.position.y - selectedG.height) * (target.transform.position.y - selectedG.height)) / selectedG.range) + 3) < (-(((target.transform.position.y - aspirantG[i].height) * (target.transform.position.y - aspirantG[i].height)) / aspirantG[i].range) + 3))
                selectedG = aspirantG[i];

            yield return new WaitForSeconds(0.01f);
        }
        if ((-(((target.transform.position.y - selectedG.height) * (target.transform.position.y - selectedG.height)) / selectedG.range) + 3) <= 0)
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
        BV = new Vector3((acI.x * tB) + ((acF.x - acI.x) * (tB) * (tB)) / 2, (acI.y * tB) + ((acF.y - acI.y) * (tB) * (tB)) / 2, 0);
        for (int i = 0; i < aspirantB.Length; i++)
        {
            aspirantB[i] = mPools.poolBad[Random.Range(0, mPools.poolBad.Length)];
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < aspirantB.Length; i++)
        {
            if (selectedB == null)
                selectedB = aspirantB[i];

            if ((-(((target.transform.position.y - selectedB.height) * (target.transform.position.y - selectedB.height)) / selectedB.range) + 3) < (-(((target.transform.position.y - aspirantB[i].height) * (target.transform.position.y - aspirantB[i].height)) / aspirantB[i].range) + 3))
                selectedB = aspirantB[i];

            yield return new WaitForSeconds(0.01f);
        }
        if ((-(((target.transform.position.y - selectedB.height) * (target.transform.position.y - selectedB.height)) / selectedB.range) + 3) <= 0)
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
