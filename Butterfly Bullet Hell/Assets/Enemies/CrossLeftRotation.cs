using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossLeftRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.AngleAxis(45, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
