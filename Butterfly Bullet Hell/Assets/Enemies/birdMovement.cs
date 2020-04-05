using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class birdMovement : MonoBehaviour
{
    public float baseSpeed = 3f;
    public bool moveRight = true;
    float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(moveRight)
        {
            transform.position = new Vector3((transform.position.x) + baseSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3((transform.position.x)- baseSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        Vector3 viewPosition = 
        Camera.main.WorldToViewportPoint(transform.position);
        if(viewPosition.x > 1 || viewPosition.x < 0)
        {
            moveRight = !moveRight;
            
            
        }
    }
}
