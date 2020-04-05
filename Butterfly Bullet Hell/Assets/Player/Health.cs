using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private CircleCollider2D circCollider;
    private SpriteRenderer render;
    public int hp = 4;
    //Frames where you are invulnerable after being hit
    public float invFrames = 60;
    // Start is called before the first frame update
    void Start()
    {
        circCollider = GetComponent<CircleCollider2D>();
        this.gameObject.tag = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        invFrames--;
        if (invFrames > 0 && (invFrames % 5 == 0 || invFrames % 5 == 1))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -20);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Friend" && invFrames < 0)
        {
            invFrames = 60;
            hp--;
        }
    }
}
