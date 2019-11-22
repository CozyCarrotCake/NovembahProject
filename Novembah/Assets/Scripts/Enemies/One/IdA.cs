using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class IdA : IdAorB
{

    public IdA()
    {
        hurtBy.Remove("b");

        speed = 2;

        jukeSpeed = 4;

        limitRange = 2;
    }

    public override void Movement()
    {
        base.Movement();
    }

    

}
