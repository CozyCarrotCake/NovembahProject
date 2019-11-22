﻿using System.Collections;
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

    GameObject[] enemies = new GameObject[15];

    public List<string> currentEnemies = new List<string>();

    
    float spawnTimer;
    bool newYeah = false;
    int whichOne;

    public float speed;
    bool changeDir = false;
    float changePos;




    // Start is called before the first frame update
    void Start()
    {
        enemies[0] = aw;
        enemies[1] = idAorB;
        enemies[2] = idA;
        enemies[3] = idB;
        enemies[4] = untAorC;
        enemies[5] = untA;
        enemies[6] = untC;
        enemies[7] = arBorC;
        enemies[8] = arB;
        enemies[9] = arC;
        enemies[10] = ilityAB;
        enemies[11] = nkBA;
        enemies[12] = rbonaraCA;
        enemies[13] = tionAC;
        enemies[14] = cab;

        changePos = Random.Range(-3.5f, 4.5f);

    }

    // Update is called once per frame
    void Update()
    {
        Spawning(enemies);

        Moving();

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

        if (newYeah == true && currentEnemies.Count < 8)
        {
            whichOne = Random.Range(0, enemies.Length);
            
            GameObject enemy = Instantiate(enemies[whichOne], transform.position + new Vector3(-1, 0, 0), transform.rotation);

            currentEnemies.Add("enemy" + currentEnemies.Count);

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


    void RemoveEnemy() //Properties här?
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
