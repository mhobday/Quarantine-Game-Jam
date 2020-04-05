using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public GameObject player;
    public GameObject heart;
    private GameObject [] hearts;

    // Start is called before the first frame update
    void Start()
    {
        hearts = new GameObject [player.GetComponent<Health>().hp];
        for(int i = 0; i < hearts.Length; i++)
        {
            GameObject helth = Instantiate(heart);
            helth.GetComponent<lives>().transform.position = new Vector3(-8 + i*1.6f, 4.5f, -5);
            hearts[i] = helth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(player.GetComponent<Health>().hp < i + 1)
            {
                hearts[i].GetComponent<lives>().Fold();
            }
        }
    }
}
