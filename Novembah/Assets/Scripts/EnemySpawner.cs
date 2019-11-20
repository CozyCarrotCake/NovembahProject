using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject hByAll;


    static Random generator = new Random();//?
    float spawnTimer;
    bool newYeah = false;

    public float speed;
    bool changeDir = false;
    float changePos;




    // Start is called before the first frame update
    void Start()
    {
        changePos = Random.Range(-4.5f, 4.5f);

    }

    // Update is called once per frame
    void Update()
    {
        Spawning();

        //Moving();
        


    }

    void Moving()
    {

        transform.Translate(Vector2.up * Time.deltaTime * speed);


        if (transform.position.y <= changePos + 0.3f && transform.position.y >= changePos - 0.3f)
        {
            changeDir = true;
        }

        if (changeDir == true)
        {
            speed *= -1;
            changeDir = false;

            if (speed > 0)
            {
                changePos = Random.Range(transform.position.y, 4.5f);
            }
            else
            {
                changePos = Random.Range(-4.5f, transform.position.y);
            }
        }        
    }

    void Spawning()
    {

        if (newYeah == true)
        {
            GameObject HbyAll = Instantiate(hByAll, transform.position, transform.rotation);
            //HbyAll.transform.Rotate(Vector2.left, 360);


            spawnTimer = Random.Range(0, 2);
            newYeah = false;
        }

        if (newYeah == false)
        {
            spawnTimer -= Time.deltaTime;

        }

        if (spawnTimer <= 0)
        {
            newYeah = true;
        }

    }






}
