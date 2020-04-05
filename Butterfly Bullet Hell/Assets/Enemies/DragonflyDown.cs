using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonflyDown : MonoBehaviour
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
        transform.position = new Vector3((transform.position.x), transform.position.y - speed, transform.position.z);
        Vector3 viewPosition = 
        Camera.main.WorldToViewportPoint(transform.position);
        if(viewPosition.y < 0)
        {
            Object.Destroy(this.gameObject);
        } 
    }
}
