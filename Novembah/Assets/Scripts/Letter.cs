using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Letter : MonoBehaviour
{

    public float speed;


    void Update()
    { 
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        OffCamera();
    }

    public void OffCamera()
    {
        if (transform.position.x > 10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        Destroy(this.gameObject);
    }

}
