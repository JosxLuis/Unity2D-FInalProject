using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    void Start()
    {
        Destroy(gameObject, 2);
    }

    private void Update()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Rock_1(Clone)"))
        {
            Destroy(gameObject);
        }
    }
}
