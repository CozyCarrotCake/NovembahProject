using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class CAB : RbonaraCA
{
    public CAB()
    {
        hurtBy.Add("b");

        speed = 2;

        goal = 0;
    }

    public override void Movement()
    {
        base.Movement();
        
        
    }

}

