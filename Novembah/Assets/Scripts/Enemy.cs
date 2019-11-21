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

    protected double limitRange;
    protected double limitPlus;
    protected double limitMinus;

    protected List<string> hurtBy = new List<string>();
    

    void Update()
    {
        Movement();

        OffCamera();
        
    }
    


    public virtual void Movement()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
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
