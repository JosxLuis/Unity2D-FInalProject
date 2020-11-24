using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wraith : MonoBehaviour
{
    public Rigidbody2D platformRB;
    public Transform[] platformPositions;
    public float platformSpeed;

    private int actualPosition = 0;
    private int nextPosition = 1;
    private Animator a;
    public Transform jugador;
    public float distance;

    public GameObject bullet;
    public Transform spawn;
    private bool allow;

    public int vida;
    public int clase;
    private Transform player;

    public float speed;
    private Vector2 target;
    public int count; // cantidad de daño
    public float damageTime;

    public AudioClip[] clips;
    private AudioSource audioSource;


    // Update is called once per frame
    void Start() {
        vida = 2;
        allow = true;
        audioSource = GetComponent<AudioSource>();

        a = GetComponent<Animator>();
        StartCoroutine(DistanceCheckJugador());
        StartCoroutine(Disparo());
        if (clase == 1)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            target = new Vector2(player.position.x, player.position.y);
        }

    }
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
            vida--;
            if (vida <= 0){
                audioSource.clip = clips[0];//muerte
                audioSource.Play();
                StopAllCoroutines();
                a.SetTrigger("dying");

                Destroy(gameObject, 1);

            }else if(vida>0)    {
                audioSource.clip = clips[1];//muerte
                audioSource.Play();

            }

        }

        
    }
    IEnumerator DistanceCheckJugador()
    {
        while (true)
        {
            //verificar si hay cambio
            float d = Vector3.Distance(transform.position, jugador.position);

            if (d < distance)
            {
               
                allow = true;
                a.SetTrigger("attack");
                Debug.Log("Cerca");
            }
            else {
                a.SetTrigger("walk");

                allow = false;
            }

            //esperar
            yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator Disparo()
    {
        while (true)
        {
            if (allow)
            {
                if (clase == 1)
                {
                    audioSource.clip = clips[2];//muerte
                    audioSource.Play();

                    Instantiate(bullet, transform.position, Quaternion.identity);

                }
                else if(clase==0)
                {
                    audioSource.clip = clips[2];//muerte
                    audioSource.Play();

                    Instantiate(bullet, spawn.position, Quaternion.Euler(0f, 180f, 0f));
                   // Instantiate(bullet, spawn.position, Quaternion.Inverse( Quaternion.Euler(0f, -180f, 0f)));sacar la negativa y ya


                }


            }


            yield return new WaitForSeconds(0.9f);
            //Dos segundos
        }

    }

}
