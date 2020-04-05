using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemicirclePattern : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float bulletAcceleration = 1f;

    [SerializeField]
    private float fireRate = 2f;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;

    // Start is called before the first frame update
    void OnEnable()
    {
        InvokeRepeating("Fire", 0f, fireRate);
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i <= bulletsAmount; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = Instantiate(bullet);
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
                bul.GetComponent<Bullet>().acceleration = this.bulletAcceleration;
                Destroy(bul, 5f);

            angle += angleStep;
        }
    }

    private void OnDisable()
    {
        CancelInvoke("Fire");
    }


}
