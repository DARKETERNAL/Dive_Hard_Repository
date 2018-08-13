using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MundoSinTienda : MonoBehaviour
{

    public bool active;
    [SerializeField]
    float probability;
    public float height, range = 50f;
    public Vector3 offSet;
    public float Probability { get { return probability; } set { probability = Mathf.Clamp(value, 0, 50); } }

    protected virtual void FixedUpdate()
    {
        if (active)
            if (Time.timeScale == 1)
                Action();
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
}
