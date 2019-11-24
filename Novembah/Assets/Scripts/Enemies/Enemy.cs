using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class Enemy : MonoBehaviour
{
    

    protected float speed;
    protected float jukeSpeed;
    protected float jukeVar;
    protected float timer;

    protected float midPos;
    protected float limit;
    protected float limitRange;
    protected float limitPlus;
    protected float limitMinus;

    protected List<string> hurtBy = new List<string>();


    public int Tutorial
    {
        get
        {
            return Tutorial;
        }
        set
        {
            Tutorial = 1;
        }
    }



    void Update()
    {
        Movement();

        OffCamera();
        
    }

    public virtual void Movement()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed * timer);
        
    }

    public virtual void OnCollisionEnter(Collision col)
    {
        
        Destroy(this.gameObject);
        
    }
    
    public void OffCamera()
    {
        if(transform.position.x < -11)
        {
            Destroy(this.gameObject);
        }
    }




}
