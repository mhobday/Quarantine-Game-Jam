using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonflyRight : MonoBehaviour
{
    public float speed = .01f;
    // Start is called before the first frame update
    void Start()
    {
        speed = .01f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((transform.position.x + speed), transform.position.y, transform.position.z);
        Vector3 viewPosition = 
        Camera.main.WorldToViewportPoint(transform.position);
        if(viewPosition.x > 1)
        {
            Object.Destroy(this.gameObject);
        } 
    }
}
