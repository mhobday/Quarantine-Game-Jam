using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonflyLeft : MonoBehaviour
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
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        Vector3 viewPosition = 
        Camera.main.WorldToViewportPoint(transform.position);
        if(viewPosition.x < 0)
        {
            Object.Destroy(this.gameObject);
        } 
    }
}
