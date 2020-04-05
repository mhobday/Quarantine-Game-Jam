using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int health = 4;

    private int counter = 0;
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Friend")
        {
            health --;
            if(health == 0)
            {
                Destroy(this.gameObject);
                
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, -200);
        }
    }

    void Update()
    {
        
        if(transform.position.z != 0)
        {
           counter++;
        }
        if(counter == 8)
        {
             transform.position = new Vector3(transform.position.x, transform.position.y, 0);
             counter = 0; 
        }
    }
}
