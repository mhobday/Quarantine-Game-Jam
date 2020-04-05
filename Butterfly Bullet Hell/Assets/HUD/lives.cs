using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lives : MonoBehaviour
{
    public GameObject player;
    public Text stock;
    // Start is called before the first frame update
    void Start()
    {
        stock = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        stock.text = "x" + player.GetComponent<Health>().hp.ToString();
    }
}
