using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Aw : Enemy
{
    protected bool doOne = true;
    protected bool doTwo = true;
    protected bool doThree = true;

    public Aw()
    {
        hurtBy.Add("pen");
        hurtBy.Add("a");
        hurtBy.Add("b");
        hurtBy.Add("c");

        speed = 3;

        jukeSpeed = 5;

        limitRange = 8;
        
        
    }

    public void Start()
    {
        
        limit = (9 - limitRange) / 2;
        if (transform.position.y < limit && transform.position.y > -limit)
        {
            limitPlus = transform.position.y + limitRange/2;
            limitMinus = transform.position.y - limitRange/2;
        }
        else if (transform.position.y >= limit)
        {
            limitPlus = 4.5f;
            limitMinus = limitPlus - limitRange;
        }
        else
        {
            limitMinus = -4.5f;
            limitPlus = limitMinus + limitRange;
        }

       

        midPos = transform.position.y;
        timer = 1;

    }



    public override void Movement()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed * timer);

        if(doOne == true)
        {
            SlowAnSpeed();
        }

        if (doTwo == true)
        {
            Jukes(); 
        }
        
        if (doThree == true)
        {
            CurvyJukes();
        }
        
               
    }

    public void SlowAnSpeed()
    {
        timer -= Time.smoothDeltaTime;
        if (timer < 0)
        {
            timer = 1;
        }
    }

    public void CurvyJukes()
    {
        if (transform.position.y > midPos)
        {
            jukeVar = limitPlus - transform.position.y;

        }
        else
        {
            jukeVar = -limitMinus + transform.position.y;
        }
    }

    public void Jukes()
    {
        transform.Translate(Vector3.up * Time.smoothDeltaTime * jukeSpeed * (jukeVar + 0.2f));


        if ((transform.position.y >= limitPlus - 0.5 && transform.position.y <= limitPlus)|| (transform.position.y <= limitMinus + 0.5 && transform.position.y >= limitMinus))
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
