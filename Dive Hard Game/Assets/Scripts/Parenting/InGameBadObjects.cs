using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InGameBadObjects : MonoBehaviour {

	 public bool active;
    // Update is called once per frame
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
