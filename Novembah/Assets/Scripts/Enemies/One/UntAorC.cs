using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class UntAorC : OneShotEnemy
{
    public UntAorC() // Har likt de andra av Aw:s subklasser samma metoder som den, förutom att vissa inte längre körs(genom do:s) och vissa variabler är olika
    {
        hurtBy.Remove("b");

        speed = 4.5f;
       
        doTwo = false;

        doThree = false;

    }


    

}

