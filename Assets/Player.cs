using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;
using UnityEngine.UI;
/**
    Referencia Disparo en la posición del mouse
    Gamesplusjames.(2019). 2D Aiming at Mouse in Unity [Youtube]. Recuperado de https://www.youtube.com/watch?v=xLtLwSgzOEo
 */
public class Player : MonoBehaviour
{
 
    public float speed;
    public Transform firepoint;
    public GameObject bullet;
    public Boolean key;
    public Text done;
    public Boolean door;
    public AudioClip[] clips;
    private AudioSource audioSource;
    public Animator a;


    private Camera cam;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        a = GetComponent<Animator>();

        cam = Camera.main;
    }

    void Update()
    {
        // Movimiento 
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(
             h * speed * Time.deltaTime,
             v * speed * Time.deltaTime,
             0,
             Space.World);
        a.SetFloat("move", h);

        Vector3 mouse = Input.mousePosition;//pos
        //Angulo 
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector2 offset = new Vector2(mouse.x - playerPos.x, mouse.y - playerPos.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,angle);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet,firepoint.position,transform.rotation);
            audioSource.clip = clips[1];
            audioSource.Play();
            a.SetTrigger("attack");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Key_0(Clone)")) {
            key = true;
            Destroy(collision.gameObject);
            audioSource.clip = clips[0];
            audioSource.Play();
        }
        if (collision.name.Equals("Rock_1(Clone)") || collision.name.Equals("Spells Effect(Clone)") || collision.name.Equals("Spells-Effect(Clone)"))
        {
            //Poner el de golpe a jugador no olvidar
            a.SetTrigger("hurt");

        }

        if (collision.name.Equals("Door0_10") && key == true)
        {
            door = true;
        }
        if (collision.name.Equals("Rock_1(Clone)") || collision.name.Equals("Spells Effect(Clone)") || collision.name.Equals("Spells-Effect(Clone)")) {
            audioSource.clip = clips[2];
            audioSource.Play();
        }
    }
   
}
