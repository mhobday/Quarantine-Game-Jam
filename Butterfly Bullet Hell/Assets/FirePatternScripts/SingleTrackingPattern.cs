using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTrackingPattern : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float fireRate = 2f;

    [SerializeField]
    private float bulletAcceleration = 1f;

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



        GameObject bul = Instantiate(bullet);
        bul.transform.position = transform.position;
        bul.transform.rotation = transform.rotation;
        bul.GetComponent<Bullet>().SetMoveDirection(bulMoveVector);
        bul.GetComponent<Bullet>().acceleration = this.bulletAcceleration;
        Destroy(bul, 5f);



    }
}
