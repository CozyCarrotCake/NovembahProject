using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class OrderEnemy : Enemy
{

    protected int added = 1;
    protected float goal;

    public OrderEnemy() //Den andra subklassen av fiender som skadas av bokstäver i en specefik order och alltid genom att krocka i penna
    {
        hurtBy.Add("pen");

        speed = 2;
    }

    public float Goal //Förändra goal variabeln i EnemySPawner
    {
        get
        {
            return goal;
        }
        set
        {
            goal = value;
        }
    }

    public override void Movement() //Rör sig genom MoveTowards, som sätter en specifik punkt, här beroende av goal-variabeln som är olika för alla, och speed
        //som bestämmer hur lång tid det tar, denna är dock samma för alla
    {

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-12.5f, goal, 0), Time.deltaTime * speed);


    }
    


    public override void OnCollisionEnter(Collision col)//Added inten börjar på 1 (pennan är 0-indexet), då bokstavs-taggarna läggs in i hurtBy-listan i en lista 
        //som specifierar ordningen som de tar skada i. Om a har index 1 och b index 2 kommer den inte ta skada av b förrän den redan tagit skada av a, vilket den
        //ser genom att jämföra taggen med added-variabeln som ändras då den tar skada av rätt. Den förstörs bara ifall den blir skadad av den sista rätta och added
        // når upp i samma siffra som fiendens hurtBylista har variabler.
    {
        if (col.gameObject.tag == hurtBy[added])
        {
            added++;
            if (added == hurtBy.Count)
            {
                base.OnCollisionEnter(col);
            }
        }

        if(col.gameObject.tag == hurtBy[0])
        {
            base.OnCollisionEnter(col);
        }

    }

}

