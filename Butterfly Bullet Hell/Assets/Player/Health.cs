using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private CircleCollider2D circCollider;
    private SpriteRenderer render;
    public int hp = 4;
    //Frames where you are invulnerable after being hit
    public float invFrames = 1f;
    //Cooldown is the length of time before you can cocoon
    public float cooldown = 2f;
    //Immune is the length of time you are immune after pressing shift
    public float immune = 0f;
    public AudioClip ouch;
    public AudioClip snacc;
    private AudioSource audi;
    // Start is called before the first frame update
    void Start()
    {
        circCollider = GetComponent<CircleCollider2D>();
        this.gameObject.tag = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        invFrames -= Time.deltaTime;
        cooldown -= Time.deltaTime;
        immune -= Time.deltaTime;
        if ((invFrames > 0 && invFrames < .1) || (invFrames > .3 && invFrames < .4) || (invFrames > .5 && invFrames < .6)
         || (invFrames > .7 && invFrames < .8) || (invFrames > .9))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -200);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift) && cooldown < 0)
        {
            cooldown = 2f;
            immune = 1f;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Friend" && invFrames < 0 && immune < 0)
        {
            invFrames = 1f;
            hp--;
            if(hp <= 0)
            {
                SceneManager.LoadScene("CreditsScene");
            }
            audi.clip = ouch;
            audi.Play();
        }

        if(col.gameObject.tag == "Power")
        {
            hp++;
            audi.clip = snacc;
            audi.Play();
        }
    }
}
