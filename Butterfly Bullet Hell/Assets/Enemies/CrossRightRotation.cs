using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossRightRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.AngleAxis(135, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
