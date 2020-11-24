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
    public Animator a;

    public AudioClip[] clips;
    private AudioSource audioSource;
    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
        a = GetComponent<Animator>();
        a.SetTrigger("walk");

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
            audioSource.clip = clips[0];//muerte
            audioSource.Play();
            a.SetTrigger("dying");

            Destroy(gameObject,1);
        }
    }
}
