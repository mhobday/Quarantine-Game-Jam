using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int health = 4;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Friend")
        {
            health --;
            if(health == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
