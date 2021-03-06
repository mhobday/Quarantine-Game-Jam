﻿using System.Collections;
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
        this.gameObject.tag = "Frog";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
