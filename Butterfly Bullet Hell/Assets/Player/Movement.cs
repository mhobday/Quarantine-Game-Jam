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
    public float delay = .3f;
    public bool caterpillar = false;
    // Start is called before the first frame update
    private CircleCollider2D circCollider;
    private Animator anim;
    void Start()
    {
        circCollider = GetComponent <CircleCollider2D> ();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(caterpillar)
        {
            anim.Play("CaterpillarWalk");
        }
        else
        {
            anim.Play("Fly");
        }
        delay -= Time.deltaTime;
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
            delay = .3f;
            GameObject bul = Instantiate(bullet);
            bul.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
            bul.GetComponent<Bullet>().SetMoveDirection(new Vector2(0, 1));
            bul.gameObject.tag = "Friend";
        }

        //Gabe's junk
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
