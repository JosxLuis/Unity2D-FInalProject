using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D platformRB;
    public Transform[] platformPositions;
    public float platformSpeed;

    private int actualPosition = 0;
    private int nextPosition = 1;

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }
    void MovePlatform()
    {
        platformRB.MovePosition(Vector2.MoveTowards(platformRB.position, platformPositions[nextPosition].position, platformSpeed * Time.deltaTime));
        if (Vector2.Distance(platformRB.position, platformPositions[nextPosition].position) <= 0)
        {
            actualPosition = nextPosition;
            nextPosition++;
            if (nextPosition > platformPositions.Length - 1)
            {
                nextPosition = 0;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Bullet_Player(Clone)"))
        {
            Destroy(gameObject);
        }
    }
}
