using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lives : MonoBehaviour
{
    public Sprite open;
    public Sprite folded;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Fold()
    {
        render.sprite = folded;
    }
    public void UnFold()
    {
        render.sprite = open;
    }
}
