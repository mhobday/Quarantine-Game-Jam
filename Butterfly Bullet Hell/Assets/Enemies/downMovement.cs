﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class downMovement : MonoBehaviour
{

    float speed = .01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.x);
        Vector3 viewPosition = 
        Camera.main.WorldToViewportPoint(transform.position);
        if(viewPosition.y < 0)
        {
            Destroy(this.gameObject);
        }
    }
}