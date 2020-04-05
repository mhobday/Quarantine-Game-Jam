using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class downMovement : MonoBehaviour
{

    public float speed = .9f;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.x);
        Vector3 viewPosition = 
        Camera.main.WorldToViewportPoint(transform.position);
        if(viewPosition.y < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
