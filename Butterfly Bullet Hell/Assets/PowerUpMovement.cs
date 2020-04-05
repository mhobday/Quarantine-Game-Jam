using System;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    public double frequency;
    public int swing;
    private double count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((float) Math.Sin(count) * swing, (float) (transform.position.y - 0.01), (float) transform.position.z);
        count += 0.01;
    }
}
