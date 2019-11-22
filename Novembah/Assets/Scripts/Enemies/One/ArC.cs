using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class ArC : ArBorC
{
    public ArC()
    {
        hurtBy.Remove("b");

        speed = 2;

        jukeSpeed = 3;

        limitRange = 2;

    }



    public override void Movement()
    {
        base.Movement();
    }
}

