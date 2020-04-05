using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralPattern : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private int bulletAmount = 4;

    private float angle = 0f;

    [SerializeField]
    private float spiralRotation = 10f;

    [SerializeField]
    private float fireRate = 0.1f;

    [SerializeField]
    private float bulletAcceleration = 1f;

    private Vector2 bulletMoveDirection;

    // Start is called before the first frame update
    void OnEnable()
    {
        InvokeRepeating("Fire", 0f, fireRate);  //The difference between the second and third parameters controls the rate of fire
    }

    private void Fire()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = Instantiate(bullet);
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
                bul.GetComponent<Bullet>().acceleration = this.bulletAcceleration;
                Destroy(bul, 5f);

            angle += 360 / bulletAmount;   //The rate at which the bullet pattern will spiral

            if (angle >= 360f)
            {
                angle -= 360f;
            }
        }

        angle += spiralRotation;
    }

    private void OnDisable()
    {
        CancelInvoke("Fire");
    }
}
