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
    //Cooldown is the length of time before you can cocoon
    public float cooldown = 120f;
    //Immune is the length of time you are immune after pressing shift
    public float immune = 0f;
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
        cooldown--;
        immune--;
        if (invFrames > 0 && (invFrames % 5 == 0 || invFrames % 5 == 1))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -200);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift) && cooldown < 0)
        {
            cooldown = 120f;
            immune = 60f;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Friend" && invFrames < 0 && immune < 0)
        {
            invFrames = 60;
            hp--;
        }
    }
}
