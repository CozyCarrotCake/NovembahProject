using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Letter : MonoBehaviour
{

    protected float speed;

    //Alla bokstäver har allt likadant förutom deras hastighet. De båda åker höger tills de antingen krockar med en fiende eller går utanför kameran.

    void Update() 
    { 
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        OffCamera();
    }

    void OffCamera()
    {
        if (transform.position.x > 10)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(this.gameObject);
    }

}
