using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Alla prefabs
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

    //Som sedan läggs i denna array för att senare kunna slumpa vilken som ska skjutas, arrayen i säg förändras aldrig förutom när jag lägger in variablerna
    //så det passar bättre än en lista
    private GameObject[] enemies = new GameObject[14];

    //Alla fiender som instanstieras läggs in här för att räkna hur många som inst.s totalt för att bestämma när banan ska avslutas, de läggs in när de skapas
    //så för att kunna använda en array istället hade jag behövt använda mig av en variabel som ändrades med array-antalet för att lägga in de i rätt index
    private List<Enemy> totalEnemies = new List<Enemy>();

    //Listor som beskriver hur många fiender som existerar samtidigt / under hjälp-genomgången i början. Finns ingen specifik indexering när de skapas så bra med lista
    private List<string> currentEnemies = new List<string>();
    private List<string> currentTutEnemies = new List<string>();

    //För spawn
    private float spawnTimer;
    private bool newYeah = false;
    private int whichOne;
    public Transform you;

    //För movement
    public float speed;
    private bool changeDir = false;
    private float changePos;

    
    int tutorial = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Lägg in alla GO i arrayen
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

        
        changePos = Random.Range(-3.5f, 4.5f);



    }
    
    void Update()
    {
        //Kallar på metoderna, FirsSpawn körs bara under tutorial medans resten körs efter
        if (tutorial < -1)
        {
            FirstSpawn();
        }
        else
        {
            Spawning();
            Moving();

            RemoveEnemy();
        }



    }




    void Moving() // Förflyttar fiendespawnern på ett slumpat sätt. Dess hastighet är alltid densamma men när den startas (i Start) får den ett slumpat värde
        //mellan dess startposition och den övre gränsen av kameran. När den når det värdet byter den riktning genom att multiplicera dess speed till ett negativt 
        //värde och får ett nytt slumpat värde som befinner sig mellan spelarens position och någon av de yttre kanterna som bestäms beroende på vilket värde dess
        //speed har och därav vilket håll den åker åt.
    {

        transform.Translate(Vector2.up * Time.smoothDeltaTime * speed);


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



    void Spawning() // Instantierar fienderna gång på gång med en slumpad väntetid. whichOne slumpar ett värde som används som indexering i fiendearrayen för att
        //slumpa vilken fiende som ska skapas- Den skapade fienden läggs till i listorna current och totalEnemies, vilka används för att se och begränsa hur många
        // fiender som finns för tillfället och hur många som skapats totalt. Det kan max vara 8 samtidigt och när 30 har skapats skapas en sista som ett slut
    {
        if (totalEnemies.Count < 30)
        {
            if (newYeah == true && currentEnemies.Count < 8)
            {
                whichOne = Random.Range(0, enemies.Length);

                GameObject enemy = Instantiate(enemies[whichOne], transform.position + new Vector3(-1, 0, 0), transform.rotation);

                
                /*fuuck help
                enemy.GetComponent<Enemy>().Name = "enemy" + totalEnemies.Count;
                currentEnemies.Add(enemy.GetComponent<Enemy>().name);


                print(currentEnemies.Count);
                print(enemy.GetComponent<Enemy>().Name);
                */

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


    void FirstSpawn() //Funkar inte för tillfället men ska funka som en tutorial där det först en fiende instantieras utan dess speciella rörelsemönster för att
        //försöka lära spelaren vad den ska göra, varav därefter de andra 3 kategorierna av fiender skjuts ut också utan deras rörelse. Rörelsen stängs av genom
        //att använda properties för att stänga av de skyddade variablerna en gång utanför klassen.
    {
        if (tutorial == 0)
        {
            GameObject enemy = Instantiate(enemies[0], you.position + new Vector3(-1, 0, 0), you.rotation);

            enemy.GetComponent<OneShotEnemy>().JukeSpeed = 0;
            enemy.GetComponent<OneShotEnemy>().DoNot = false;

            currentTutEnemies.Add("enemy");

            tutorial = 1;

            if (GameObject.Find(currentTutEnemies[0]) == null)
            {
                tutorial = 2;
            }
        }
        else if (tutorial == 2)
        {
            int which = Random.Range(1, 4);
            GameObject enemy = Instantiate(enemies[which], you.position + new Vector3(-1, 0, 0), you.rotation);

            enemy.GetComponent<OneShotEnemy>().JukeSpeed = 0;
            enemy.GetComponent<OneShotEnemy>().DoNot = false;
            currentTutEnemies.Add("enemy");
            tutorial = 3;
        }
        else if (tutorial == 4)
        {
            int which = Random.Range(4, 10);
            GameObject enemy = Instantiate(enemies[which], you.position + new Vector3(-1, 0, 0), you.rotation);

            enemy.GetComponent<OneShotEnemy>().JukeSpeed = 0;
            enemy.GetComponent<OneShotEnemy>().DoNot = false;
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



    } // Need the help above



    void RemoveEnemy()//fuckiducki //Tar bort fienden från currentenemies när den slutar existera
    {
        for (int i = 0; i < currentEnemies.Count; i++)
        {
            //if ()
            //{
              //  currentEnemies.Remove(currentEnemies[i]);
            //}
        }

    }




}
