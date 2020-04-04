using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class turretAim : MonoBehaviour
{
    UnityEngine.Object player;//get player object here
    double rotationSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float slopeX = player.transform.position.x - transform.position.x;
        float slopeY = player.transform.position.y - transform.position.y;

        double targetAngle = System.Math.Atan(slopeY / slopeX);
        targetAngle *=  57.2958f;
        
        float currentAngle = transform.localEulerAngles.z;

        if(currentAngle > targetAngle)
        {
            if(currentAngle - rotationSpeed <= targetAngle)
            {
                transform.Rotate(0,0,currentAngle - targetAngle);
            }
            else
            {
                transform.Rotate(0,0,currentAngle - rotationSpeed);
            }
        }
        else
        {
            if(currentAngle + rotationSpeed >= targetAngle)
            {
                currentAngle = targetAngle;
            }
            else
            {
                currentAngle += rotationSpeed;
            }
        }





    }
}
