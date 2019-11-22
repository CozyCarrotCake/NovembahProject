using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ArBorC : Aw
{
    public ArBorC()
    {
        hurtBy.Remove("a");

        speed = 2;

        jukeSpeed = 3;

        limitRange = 4;

        doOne = false;

        doThree = false;
    }



    public override void Movement()
    {
        base.Movement();
    }
}

