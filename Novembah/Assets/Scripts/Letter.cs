﻿using System;
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
    }



}