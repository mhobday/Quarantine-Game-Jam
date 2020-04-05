using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTrackingPattern : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float fireRate = 2f;

    private Vector2 bulletMoveDirection;

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Fire", 0f, fireRate);
    }

    private void Fire()
    {
        
        Vector3 bulMoveVector = (target.transform.position - transform.position).normalized;

        

        GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
        bul.transform.position = transform.position;
        bul.transform.rotation = transform.rotation;
        bul.SetActive(true);
        bul.GetComponent<Bullet>().SetMoveDirection(bulMoveVector);

            
   
    }
}
