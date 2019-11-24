using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    public GameObject letterA;
    public GameObject letterB;
    public GameObject letterC;
    public Transform you;
    

    public float penSpeed;

    List<A> currentAs = new List<A>();
    List<B> currentBs = new List<B>();
    List<C> currentCs = new List<C>();

    int lives = 3;

    
    

    void Update()
    {

        Move();

        WhichShot();
        


        Death();

    }

    void Move() // Vertikal rörelse, när den kommer under eller över 5 teleporteras man till andra sidan
    {
        float moveY = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector2.up * moveY * Time.deltaTime * penSpeed);

        if (transform.position.y > 5)
        {
            transform.position = new Vector3(-8, -4.9f, 0);
        }
        else if (transform.position.y < -5)
        {
            transform.position = new Vector3(-8, 4.9f, 0);
        }
    }

     
    void WhichShot() //Vad man skjuter beror på vad man trycker på
    {
        //a
        bool attackA = Input.GetKeyDown(KeyCode.A);
        if (attackA == true)
        {
            //Instantiate
            ShootA();
        }

        //b
        bool attackB = Input.GetKeyDown(KeyCode.B);
        if (attackB == true)
        {
            ShootB();
        }

        //c
        bool attackC = Input.GetKeyDown(KeyCode.C);
        if (attackC == true)
        {
            ShootC();
        }
    }

    void ShootA()//Instantierar en A-prefab som jag sparat i letterA objektet som här skapas som aObject objektet, i pennans position och rotation och som läggs
        //till i currentAs listan
    {
        GameObject aObject = Instantiate(letterA, you.position, you.rotation);
        currentAs.Add(aObject.GetComponent<A>());

        aObject.transform.Rotate(Vector3.right, 360);

    }


    void ShootB()
    {
        GameObject bObject = Instantiate(letterB, you.position, you.rotation);
        currentBs.Add(bObject.GetComponent<B>());

        bObject.transform.Rotate(Vector3.right, 360);

    }


    void ShootC()
    {
        GameObject cObject = Instantiate(letterC, you.position, you.rotation);

        currentCs.Add(cObject.GetComponent<C>());

        
        cObject.transform.Rotate(Vector3.right, 360);
        
    }



    private void OnCollisionEnter(Collision col) //Tar skada när den kolliderar med en fiende
    {
        if (col.gameObject.tag != "a" || col.gameObject.tag != "b" || col.gameObject.tag != "c")
        {
            lives--;
        }

    }
    
    private void Death() // Vid 3 slag dör man
    {
        if (lives == 0)
        {
            Destroy(this.gameObject);
        }
    }

}
