using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDirection;

    [SerializeField]
    private float initialSpeed = 5f;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    public float acceleration = 1f;

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
        this.moveSpeed = this.initialSpeed;
        InvokeRepeating("Accelerate", 0f, 0.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    public void Accelerate()
    {
        moveSpeed *= this.acceleration;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
