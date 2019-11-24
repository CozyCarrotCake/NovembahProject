using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ArBorC : OneShotEnemy
{
    public ArBorC() //Skadas inte längre av a
    {
        hurtBy.Remove("a");

        speed = 2;

        jukeSpeed = 3;

        limitRange = 4;

        doOne = false;

        doThree = false;
    }

    
}

