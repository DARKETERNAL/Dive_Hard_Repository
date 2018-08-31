using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public Transform[] pool;
    List<Transform> poolList = new List<Transform>();

    
    public Transform player;
    public float spriteWidth;

    [SerializeField]
    float distanceToSpawn;

    float spriteDistance;

    float distance;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            poolList.Add(pool[i]);
        }

        spriteDistance = (pool.Length * spriteWidth);

    }


    private void Update()
    {
        distance = player.position.x;

        if (spriteDistance < (distance+(spriteWidth*2)))
        {
            int rand = Random.Range(0, 4);
            Transform temp = poolList[rand];
            poolList.RemoveAt(rand);
            temp.position = new Vector3( spriteDistance-(distanceToSpawn) , temp.position.y, temp.position.z);
            poolList.Add(temp);
            spriteDistance += spriteWidth;
        }
    }


}
