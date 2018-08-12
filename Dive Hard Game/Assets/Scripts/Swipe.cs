using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : PassiveMechanics
{
    Vector2 intial, final, vecMov;
    [SerializeField]
    float minDis, magnitud;
    Rigidbody2D me;
    protected override void Execution() //start
    {
        me = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
            intial = Input.mousePosition;
        if (Input.GetButtonUp("Fire1"))
        {
            final = Input.mousePosition;
            vecMov = (final - intial).normalized;
            if (Vector2.Distance(final, intial) >= minDis)
                me.AddForce(vecMov * magnitud, ForceMode2D.Impulse);
        }
    }
}
