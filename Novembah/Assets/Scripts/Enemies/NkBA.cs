using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class NkBA : OrderEnemy
{
    public NkBA()
    {
        hurtBy.Add("a");
        hurtBy.Add("b");

        speed = 2;

        goal = 2.3f;
    }

    public override void Movement()
    {
        base.Movement();
        
        
        
    }

}

