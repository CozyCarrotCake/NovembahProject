using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject aw;
    public GameObject idAorB;
    public GameObject idA;
    public GameObject idB;
    public GameObject untAorC;
    public GameObject untA;
    public GameObject untC;
    public GameObject arBorC;
    public GameObject arB;
    public GameObject arC;
    public GameObject ilityAB;
    public GameObject nkBA;
    public GameObject rbonaraCA;
    public GameObject tionAC;
    public GameObject cab;

    private GameObject[] enemies = new GameObject[14];

    private List<Enemy> totalEnemies = new List<Enemy>();

    private List<string> currentEnemies = new List<string>();
    private List<string> currentTutEnemies = new List<string>();


    private float spawnTimer;
    private bool newYeah = false;
    private int whichOne;

    public float speed;
    private bool changeDir = false;
    private float changePos;

    public Transform you;

    int tutorial = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemies[0] = aw;
        enemies[1] = idAorB;
        enemies[2] = untAorC;
        enemies[3] = arBorC;
        enemies[4] = idA;
        enemies[5] = idB;
        enemies[6] = untA;
        enemies[7] = untC;
        enemies[8] = arB;
        enemies[9] = arC;
        enemies[10] = ilityAB;
        enemies[11] = nkBA;
        enemies[12] = rbonaraCA;
        enemies[13] = tionAC;
        //enemies[14] = cab;

        changePos = Random.Range(-3.5f, 4.5f);



    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial < -1)
        {
            FirstSpawn();
        }
        else
        {
            Spawning(enemies);
            Moving();
        }
        print(currentEnemies.Count);
        

        RemoveEnemy();

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



    void Spawning(GameObject[] enemies)
    {
        if (totalEnemies.Count < 20)
        {
            if (newYeah == true && currentEnemies.Count < 8)
            {
                whichOne = Random.Range(0, enemies.Length);

                GameObject enemy = Instantiate(enemies[whichOne], transform.position + new Vector3(-1, 0, 0), transform.rotation);

                currentEnemies.Add("enemy" + currentEnemies.Count);

                totalEnemies.Add(enemies[whichOne].GetComponent<Enemy>());

                spawnTimer = Random.Range(1f, 2.5f);
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
        else
        {
            GameObject enemy = Instantiate(cab, transform.position + new Vector3(-1, 0, 0), transform.rotation);

            //QUE FIN
        }


    }


    void FirstSpawn()
    {
        if (tutorial == 0)
        {
            GameObject enemy = Instantiate(enemies[0], you.position + new Vector3(-1, 0, 0), you.rotation);

            enemy.GetComponent<Aw>().JukeSpeed = 0;
            enemy.GetComponent<Aw>().DoNot = false;

            currentTutEnemies.Add("enemy");

            tutorial = 1;

            if (GameObject.Find(currentTutEnemies[0]) == null)
            {
                tutorial=2;
            }
        }
        else if (tutorial == 2)
        {
            int which = Random.Range(1, 4);
            GameObject enemy = Instantiate(enemies[which], you.position + new Vector3(-1, 0, 0), you.rotation);

            enemy.GetComponent<Aw>().JukeSpeed = 0;
            enemy.GetComponent<Aw>().DoNot = false;
            currentTutEnemies.Add("enemy");
            tutorial = 3;
        }
        else if (tutorial == 4)
        {
            int which = Random.Range(4, 10);
            GameObject enemy = Instantiate(enemies[which], you.position + new Vector3(-1, 0, 0), you.rotation);

            enemy.GetComponent<Aw>().JukeSpeed = 0;
            enemy.GetComponent<Aw>().DoNot = false;
            currentTutEnemies.Add("enemy");
            tutorial = 5;
        }
        else if (tutorial == 6)
        {
            int which = Random.Range(10, 14);
            GameObject enemy = Instantiate(enemies[which], you.position + new Vector3(-1, 0, 0), you.rotation);

            enemy.GetComponent<OrderEnemy>().Goal = 0;
            currentTutEnemies.Add("enemy");
            tutorial = 7;
        }



    }



    void RemoveEnemy()
    {
        for (int i = 0; i < currentEnemies.Count; i++)
        {
            if (GameObject.Find(currentEnemies[i]) == null)
            {
                currentEnemies.Remove(currentEnemies[i]);
            }
        }

    }
    



}
