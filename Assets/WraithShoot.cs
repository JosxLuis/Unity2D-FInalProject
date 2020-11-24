using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithShoot : MonoBehaviour
{
    public float speed;
    private Transform player;
    Player_Life lifeplayer;
    private Vector2 target;
    public int count; // cantidad de daño
    public float damageTime;
    float currentDamageTime;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lifeplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Life>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.right * -speed );
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.name.Equals("Player"))
        {


            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {

                lifeplayer.life += count;

                currentDamageTime = 0.0f;
            }
            Destroy(gameObject);

        }

        if (collision.name.Equals("Bullet_Player(Clone)"))
        {

            Destroy(gameObject);
        }
    }
}
