﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class TionAC : OrderEnemy
{
    public TionAC()
    {
        hurtBy.Add("a");
        hurtBy.Add("c");

        speed = 2;

        goal = -4.3f;
    }

    public override void Movement()
    {
        base.Movement();
        
        
        
    }

}
