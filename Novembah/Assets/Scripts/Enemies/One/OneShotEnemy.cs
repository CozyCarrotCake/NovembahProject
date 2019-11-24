using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OneShotEnemy : Enemy
{
    //Den ena subklassen av fiender som skadas av en specifik bokstav

    //De tre specifika rörelsesätten
    //1 ger en hackig hastighet
    protected bool doOne = true;
    //2 ger ett zickzackmönster
    protected bool doTwo = true;
    //3 ger ett vågmönster
    protected bool doThree = true;

    public OneShotEnemy()
    {
        //Aw och dess subklasser tar skada av minst en av dessa (alla pen), så de läggs alla till här för att sedan tas bort av subklasserna
        hurtBy.Add("pen");
        hurtBy.Add("a");
        hurtBy.Add("b");
        hurtBy.Add("c");

        speed = 3;

        jukeSpeed = 5;

        limitRange = 8;
    }
    
    public bool DoNot //Property som låter ENemySpawner förändra denna skyddade bool för att stänga av rörelsemönster
    {
        get
        {
            return doOne;
        }
        set
        {
            doOne = value;
        }
    }



    public float JukeSpeed
    {
        get
        {
            return jukeSpeed;
        }
        set
        {
            jukeSpeed = value;
        }
        
    }
    

    public void Start() // Den får ett par värden när den skapas som bestämmer i vilka ramar som de kommer åka i. Dess totala gräns bestäms tidigare av limitRange
        //och är den enda skillnaden mellan de olika subklasserna vad det gäller detta. 
    {

        limit = (9 - limitRange) / 2; //Limit används för att bestämma om den är för nära kamerans yttre gränser eller inte (Kameran är 9). Om den är för nära 
        //sätts gränsen automatiskt vid 4.5/-4.5 (kanterna) och den andra gränsen sätts limitrangen därifrån så att de alltid har dess limitrange som rörelserum.
        if (transform.position.y < limit && transform.position.y > -limit)
        {
            limitPlus = transform.position.y + limitRange / 2;
            limitMinus = transform.position.y - limitRange / 2;
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


        //Sätts som en startposition för senare rörelsemönster
        midPos = transform.position.y;
        timer = 1;

    }



    public override void Movement() //Körs vänster med någon kombination av rörelsemönster
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed * timer);

        if (doOne == true)
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

    public void SlowAnSpeed() // höjer och skjunker hastigheten med en tidsvariabel som används som en faktor i Movements transform.Translate
    {
        timer -= Time.smoothDeltaTime;
        if (timer < 0)
        {
            timer = 1;
        }
    }

    public void CurvyJukes() //Gör så att rörelsemönstret lir lite kurvigt, då hastigheten blir lägre desto närmare kanterna man är, variabeln används som en faktor i 
        //nästa metod
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

    public void Jukes() //När den är i en avgränsad del av kanterna byter den riktning i y-led, jukeVar variabeln används för att göra den kurvig, men går inte
        //ner till 0 då det skulle leda till att den stannade när den kom upp till gränsen.
    {
        transform.Translate(Vector3.up * Time.smoothDeltaTime * jukeSpeed * (jukeVar + 0.2f));


        if ((transform.position.y >= limitPlus - 0.5 && transform.position.y <= limitPlus) || (transform.position.y <= limitMinus + 0.5 && transform.position.y >= limitMinus))
        {
            jukeSpeed *= -1;
        }
    }

    public override void OnCollisionEnter(Collision col) // Den overrideade kollisionsmetoden som nu enbart händer när den kolliderar med någon av de med rätt tag
    {
        if (hurtBy.Contains(col.gameObject.tag))
        {
            base.OnCollisionEnter(col);
        }
    }



}
