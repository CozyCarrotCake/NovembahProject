using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class TionAC : OrderEnemy
{
    public TionAC()
    {
        hurtBy.Add("c");
        hurtBy.Add("a");
                
        goal = -4.3f;
    }
    

}

