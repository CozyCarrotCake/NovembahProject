using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenScript : MonoBehaviour
{

    public GameObject letterA;
    public GameObject letterB;
    public GameObject letterC;
    public Transform you;

    List<A> currentAs = new List<A>();
    List<B> currentBs = new List<B>();
    List<C> currentCs = new List<C>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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



    void ShootA()
    {
        GameObject aObject = Instantiate(letterA, you.position, you.rotation);
        currentAs.Add( aObject.GetComponent<A>() );
          
        aObject.transform.Rotate(Vector3.forward, 360);

    }


    void ShootB()
    {
        GameObject bObject = Instantiate(letterB, you.position, you.rotation);
        currentBs.Add(bObject.GetComponent<B>());
               
        bObject.transform.Rotate(Vector3.forward, 360);

    }


    void ShootC()
    {
        GameObject cObject = Instantiate(letterC, you.position, you.rotation);
        currentCs.Add(cObject.GetComponent<C>());
               
        cObject.transform.Rotate(Vector3.forward, 360);

    }
}
