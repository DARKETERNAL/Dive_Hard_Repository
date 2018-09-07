using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MundoSinTienda : MonoBehaviour
{
    public bool active;
    [SerializeField]
    int probability;
    public float height, inverseRange = 0.02f;
    public Vector3 offSet;
    public int Probability { get { return probability; } set { probability = Mathf.Clamp(value, 0, 50); } }
    public Vector2 pobRange;

    bool counting = false;
    float maxPoolingDistance;
    Transform player;
    
    public Rigidbody2D selfR;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        selfR = GetComponent<Rigidbody2D>();
        selfR.simulated = false;
    }
    protected virtual void FixedUpdate()
    {

        if (active)
            if (Time.timeScale == 1)
                Action();

        if (active)
            DistancePooling();
    }
    protected abstract void Action();
    protected virtual IEnumerator Activation(Player _jugador)
    {
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
            if (collision.GetComponent<Player>() != null)
                StartCoroutine(Activation(collision.GetComponent<Player>()));
    }
    protected void BackToPool()
    {
        active = false;
        counting = false;
        transform.position = new Vector3(-500, -500, 0);
        selfR.velocity = Vector2.zero;
        selfR.simulated = false;
    }
    void DistancePooling()
    {       
        if (!counting)
        {    
            maxPoolingDistance = Vector3.Distance(transform.position, player.position) + 2;
        }
        counting = true;
        if (Vector3.Distance(transform.position, player.position) > maxPoolingDistance)
        {
            BackToPool();
        }
    }
}
