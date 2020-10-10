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

    private Camera cam;
    void Start()
    {
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
    
        Vector3 mouse = Input.mousePosition;//pos
        //Angulo 
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector2 offset = new Vector2(mouse.x - playerPos.x, mouse.y - playerPos.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,angle);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet,firepoint.position,transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Key_0(Clone)")) {
            key = true;
            Destroy(collision.gameObject);
        }

        if (collision.name.Equals("Door0_10") && key == true)
        {
            door = true;
        }
    }
   
}
