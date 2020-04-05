using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    //Used in all movement funcions to decide how far to move
    public float baseSpeed = 4f;
    //Delay is the amount of time before you can fie again
    public float delay = 10f;
    public bool caterpillar = false;
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
            transform.position = new Vector3(transform.position.x - baseSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + baseSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + baseSpeed * Time.deltaTime, transform.position.z);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - baseSpeed * Time.deltaTime, transform.position.z);
        }
        if (Input.GetKey(KeyCode.Space) && delay < 0)
        {
            delay = 10f;
            GameObject bul = Instantiate(bullet);
            bul.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            bul.GetComponent<Bullet>().SetMoveDirection(new Vector2(0, 1));
            bul.gameObject.tag = "Friend";
        }
        Vector3 viewPosition = 
        Camera.main.WorldToViewportPoint(transform.position);
        float sideOffset = .03f;
        if(caterpillar)
        {
            sideOffset = .095f;
        }
        if(viewPosition.x < sideOffset)
        {
            transform.position = new Vector3(transform.position.x + baseSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if(viewPosition.x > 1 - sideOffset)
        {
            transform.position = new Vector3(transform.position.x - baseSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if(viewPosition.y < .09)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + baseSpeed * Time.deltaTime, transform.position.z);
        }
        else if(viewPosition.y > .9)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - baseSpeed * Time.deltaTime, transform.position.z);
        }
    }
}
