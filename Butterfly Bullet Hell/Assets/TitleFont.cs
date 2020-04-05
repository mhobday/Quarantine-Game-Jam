using System;
using UnityEngine;
using UnityEngine.UI;

public class TitleFont : MonoBehaviour
{
    public int swing;
    private double count = 0;
    public double frequency;
    public Text text;
    RectTransform rectTransform;
    Vector3 rotationEuler;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // rotationEuler += Vector3.forward*30*Time.deltaTime;
        // rectTransform.rotation = Quaternion.Euler(rotationEuler);
        rectTransform.rotation = Quaternion.Euler(0, 0, (float) Math.Sin(count) * swing);
        count += frequency;
    }
}
