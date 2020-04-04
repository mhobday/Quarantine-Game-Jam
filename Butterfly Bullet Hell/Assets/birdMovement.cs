using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class birdMovement : MonoBehaviour
{
    float baseSpeed = .01f;
    bool moveRight = true;
    float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x >= 0)
        {
            moveRight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(moveRight)
        {
            transform.position = new Vector3((transform.position.x + baseSpeed), transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3((transform.position.x - baseSpeed), transform.position.y, transform.position.z);
        }
        Vector3 viewPosition = 
        Camera.main.WorldToViewportPoint(transform.position);
        if(viewPosition.x > 1 || viewPosition.x < 0)
        {
            moveRight = !moveRight;
            
            
        }
        if(timer >= 2)
        {
            //Shoot egg
            print("shoot");
            timer = 0;
        }
    }
}
