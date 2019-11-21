using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Aw : Enemy
{
    

    public Aw()
    {
        hurtBy.Add("pen");
        hurtBy.Add("a");
        hurtBy.Add("b");
        hurtBy.Add("c");

        speed = 3;

        jukeSpeed = 3;

        limitRange = 4.5;
    }

    public virtual void Start()
    {
        limitPlus = transform.position.y + limitRange - transform.position.y;
        limitMinus = transform.position.y - limitRange + transform.position.y;
    }

    public override void Movement()
    {
        base.Movement();

        transform.Translate(Vector3.up * Time.deltaTime * jukeSpeed);

        if (transform.position.y > limitPlus || transform.position.y < limitMinus)
        {
            jukeSpeed *= -1;
        }



    }

    public override void OnCollisionEnter(Collision col)
    {
        if (hurtBy.Contains(col.gameObject.tag))
        {
            base.OnCollisionEnter(col);
        }
    }
    
    

}
