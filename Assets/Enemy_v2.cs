using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_v2 : MonoBehaviour { 


    public float visionRadius;
    public float attackRadius;
    public float speed;
    GameObject player;
    Vector3 initialPosition;

    //public CharacterController2D controller;

    public Animator anim;
    Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // nuestra targe es la posicion inicial
        Vector3 target = initialPosition;
        // comprobamos un raycast del hasta el jugador
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, visionRadius, 1 << LayerMask.NameToLayer("Default"));
        // ponemos el propio enemigo en un layer distinta a defaul para eviar el raycast

        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

        //si encuentra al jugador ponemos su target
        if (hit.collider != null) {
            if (hit.collider.tag ==  "Player") {
                target = player.transform.position;
            }
        }

        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;


        if (target != initialPosition && distance < attackRadius)
        {

            // animacion para atacar
           
            anim.Play("Walking", -1, 0);

            //anim.SetBool("atack", true);

        }// en caso lo contrario nos movemos hacia el 
        else {
            rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);
            // animaciones
            // avanzamos la animacion
            //anim.SetBool("atack", false);
            anim.SetFloat("speed", speed * Time.deltaTime);
            

        }

        if (target == initialPosition && distance < 0.02f) {
            transform.position = initialPosition;
            // detenemos la animacion
            anim.SetFloat("speed", 0);
            
        }

        Debug.DrawLine(transform.position, target, Color.green);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

}
