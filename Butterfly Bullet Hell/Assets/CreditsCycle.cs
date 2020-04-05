using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsCycle : MonoBehaviour
{
    private string[] contributors;
    private double count;
    public Text t;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        contributors = new string[] {"Alex Ramsey\n-Programmer-","Gabe Drew\n-Programmer-","Jaymeson\n-Music Producer-","Kyle Phipps\n-Programmer-","Max Hobday\n-Programmer-","Oliver Coffman\n-Sound Designer-","Ryan Narducci\n-Art Director-"};
        t = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime * 0.5;
        t.text = contributors[(int)count % contributors.Length];
    }
}
