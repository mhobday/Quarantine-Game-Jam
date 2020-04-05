using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    //Used in all movement funcions to decide how far to move
    public float baseSpeed = .05f;
    //Delay is the amount of time before you can fie again
    public float delay = 10f;
    // Start is called before the first frame update
    private CircleCollider2D circCollider;
    void Start()
    {
        circCollider = GetComponent <CircleCollider2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        delay--;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - baseSpeed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + baseSpeed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + baseSpeed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - baseSpeed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.Space) && delay < 0)
        {
            delay = 10f;
            GameObject bul = Instantiate(bullet);
            bul.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            bul.GetComponent<Bullet>().SetMoveDirection(new Vector2(0, 1));
            bul.gameObject.tag = "Friend";
        }
    }
}
