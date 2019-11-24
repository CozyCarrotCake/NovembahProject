using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class IdAorB : OneShotEnemy
{
    
    public IdAorB() // Tar bort c från de skadliga och hackade hastigheten från rörelseschemat och lite andra variabelförändringar
    {
        hurtBy.Remove("c");

        speed = 3;

        jukeSpeed = 4;

        limitRange = 4;

        doOne = false;

    }
    

    

    
    


}

