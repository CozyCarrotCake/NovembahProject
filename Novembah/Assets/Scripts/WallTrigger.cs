using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    public GameObject gameOverScreen;

    private int lives = 3;
    

    void Update()
    {
        if (lives == 0)
        {
            gameOverScreen.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        print(lives);
        lives--;
        
        
    }



}


