﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript : MonoBehaviour
{

    public float vel;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * vel);


    }
}
