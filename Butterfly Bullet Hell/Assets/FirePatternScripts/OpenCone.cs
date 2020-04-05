using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCone : MonoBehaviour
{
    private bool moveClockwise = true;

    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float bulletAcceleration = 1f;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    [SerializeField]
    private float fireRate = 0.1f;

    [SerializeField]
    private float coneWidth = 30f;

    [SerializeField]
    private float coneRotation = 0f;

    [SerializeField]
    private float coneRotationRange = 45f;

    [SerializeField]
    private float coneRotationRate = 5f;

    private Vector2 bulletMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, fireRate);  //The third parameter controls the rate of fire
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        if (coneRotation + coneWidth >= 180)
        {
            angle += 360;
        }

        for (int i = 0; i <= bulletsAmount; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            if (angle <= ((endAngle - startAngle) / 2) + coneRotation - coneWidth || angle >= ((endAngle - startAngle) / 2) + coneRotation + coneWidth)
            {
                GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
                bul.GetComponent<Bullet>().acceleration = this.bulletAcceleration;
            }

            angle += angleStep;

        }

        if(moveClockwise)
        {
            coneRotation += coneRotationRate;

            if(coneRotation >= coneRotationRange)
            {
                moveClockwise = false;
            }
        }
        else
        {
            coneRotation -= coneRotationRate;

            if (coneRotation <= (-1) * coneRotationRange)
            {
                moveClockwise = true;
            }
        }
    }
}
