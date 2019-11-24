using System;
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
        
        goal = 4.3f;
    }
    

}

