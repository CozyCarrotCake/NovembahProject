using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class RbonaraCA : OrderEnemy
{
    public RbonaraCA()
    {
        hurtBy.Add("a");
        hurtBy.Add("c");

        speed = 2;

        goal = -2.3f;
    }

    public override void Movement()
    {
        base.Movement();
        
        
    }

}

