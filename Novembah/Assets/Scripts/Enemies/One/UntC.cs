using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class UntC : UntAorC
{
    public UntC()
    {
        hurtBy.Remove("a");

        speed = 3;

    }



    public override void Movement()
    {
        base.Movement();
    }
}

