using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class Enemy : MonoBehaviour
{
    public string[] hurtBy = new string[3];

    public float speed;
    


    public void Hurt()
    {
        //if collision with correct from hurtBy

    }


    public virtual void Movement()
    {
        transform.Translate(Vector2.left * Time.deltaTime); //forward?
    }

}
