﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class IlityAB : OrderEnemy
{
    public IlityAB()
    {
        hurtBy.Add("b");
        hurtBy.Add("a");

        speed = 2;

        goal = 4.3f;
    }

    public override void Movement()
    {
        base.Movement();
        
        
        
    }

}

