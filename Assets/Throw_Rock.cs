﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_Rock : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
  
        
    }

    void Update()
    {
        if (timeBtwShots <= 0)
        {
            
            
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
    }
}
