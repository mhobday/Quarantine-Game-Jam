using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonflyDown : MonoBehaviour
{
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        this.gameObject.tag = "Dragonfly";
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((transform.position.x), transform.position.y - speed * Time.deltaTime, transform.position.z);
        Vector3 viewPosition = 
        Camera.main.WorldToViewportPoint(transform.position);
        if(viewPosition.y < 0)
        {
            Object.Destroy(this.gameObject);
        } 
    }
}
