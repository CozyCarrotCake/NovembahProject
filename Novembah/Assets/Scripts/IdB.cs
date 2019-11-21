using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class IdB : IdAorB
{
    public IdB()
    {
        hurtBy.Remove("a");

        speed = 3;

        limitRange = 2;
    }

    public override void Movement()
    {
        base.Movement();
    }

    
}
