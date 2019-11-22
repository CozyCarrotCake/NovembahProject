using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class ArB : ArBorC
{
    public ArB()
    {
        hurtBy.Remove("c");

        speed = 3;

        jukeSpeed = 3;

        limitRange = 2;

    }



    public override void Movement()
    {
        base.Movement();
    }
}

