using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class Enemy : MonoBehaviour
{
    //variablerna är protected för att skydda de men även för att låta de existera i dess subklasser
    protected float speed;
    protected float jukeSpeed;
    protected float jukeVar;
    protected float timer;

    protected float midPos;
    protected float limit;
    protected float limitRange;
    protected float limitPlus;
    protected float limitMinus;

    //En lista där det som skadar fienden läggs till
    protected List<string> hurtBy = new List<string>();

    public string name;

    public Enemy() //Oklart vi får se
    {
        name = "enemy";
    }


    public int Tutorial //Också oklart
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

    public string Name { get; set; }//Oklart ocksåå



    void Update() // Den update som körs för alla fiender med de två metoder som alla använder och som behövs köras i Update.
    {
        Movement();

        OffCamera();
        
    }

    public virtual void Movement()//Alla fiender åker vänster, dock med vissa speciella funktioner vilket är varför den är virtual så att andra kan overridea den 
        //och lägga till specifika rörelsemönster, men det viktiga är att de ändå körs i Update, som enemy är den enda fiendeklassen som har.
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed * timer);
        
    }

    public virtual void OnCollisionEnter(Collision col) //Förstörs när de kolliderar, men alla fiender dör av specifika bokstäver vilket gör att de behöver overridea denna
    {
        Destroy(this.gameObject);
        
    }
    
    public void OffCamera() // Den här använder all exakt, när den når denna punkt utanförspelet ska den förstöras
    {
        if(transform.position.x < -12)
        {
            Destroy(this.gameObject);
        }
    }




}
