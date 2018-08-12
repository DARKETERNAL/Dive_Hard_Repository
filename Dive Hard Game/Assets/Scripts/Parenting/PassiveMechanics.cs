using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveMechanics : StoreObjectsParent {

    private void Start()
    {
        Execution();
    }
    protected abstract void Execution();
   
}
