  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{

  
    public ObjectsParents[] pool;
    public int  maxProb;

    // Use this for initialization
    void Awake()
    {
      
        ObjectsParents[] tempPool = Resources.LoadAll<ObjectsParents>("Prefabs");
 
        pool = new ObjectsParents[tempPool.Length * 3];
        for (int i = 0; i < pool.Length; i += tempPool.Length)
        {
            for (int j = 0; j < tempPool.Length; j++)
            {
                pool[i + j] = Instantiate(tempPool[j], new Vector3(-500, -500, 0), Quaternion.identity);
                pool[i + j].pobRange = new Vector2(maxProb,maxProb + pool[i + j].Probability - 1);
                maxProb += pool[i + j].Probability;
                //Debug.Log(string.Format("{0} [{1},{2}] {3} / {4}", pool[i + j].Probability,maxProb - pool[i + j].Probability, maxProb - 1, maxProb, pool[i + j].name));
            }
        }
    }
}
