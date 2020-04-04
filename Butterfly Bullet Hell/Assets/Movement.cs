using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Used in all movement funcions to decide how far to move
        private float baseSpeed = .05f;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = new Vector3(transform.position.x - baseSpeed, transform.position.y, transform.position.z);
            }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = new Vector3(transform.position.x + baseSpeed, transform.position.y, transform.position.z);
            }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + baseSpeed, transform.position.z);
            }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - baseSpeed, transform.position.z);
            }
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Enter))
        {

        }
    }
}
