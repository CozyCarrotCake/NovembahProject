using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class OrderEnemy : Enemy
{

    protected int added = 0;
    protected float goal;

    public override void Movement()
    {
        base.Movement();
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-11, goal, 0), 0.1f);
    }
    

    public override void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == hurtBy[added])
        {
            added++;
            if (added == hurtBy.Count)
            {
                base.OnCollisionEnter(col);
            }

        }

    }

}

