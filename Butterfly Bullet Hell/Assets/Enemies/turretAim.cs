using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class turretAim : MonoBehaviour
{
    public UnityEngine.GameObject player;
    //public float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = player.transform.position - transform.position;
    }
}
