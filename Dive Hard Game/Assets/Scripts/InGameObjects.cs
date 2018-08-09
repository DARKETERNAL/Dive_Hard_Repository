using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InGameObjects : StoreObjectsParent {

	// Update is called once per frame
	protected virtual void FixedUpdate () {
		if (Time.timeScale == 1)
        {
            Action();
        }
	}
    protected abstract void Action();
    protected virtual IEnumerator Activation()
    {
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            StartCoroutine(Activation());
        }
    }
}
