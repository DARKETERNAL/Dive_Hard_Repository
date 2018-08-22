using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edificio : PassiveMechanics
{
    private float altura;
    public float Altura { get { return altura; } set { altura = value * ActualLevel ;} }
    protected override void Execution()//start
    {
        Altura = 1000;
    }
}
