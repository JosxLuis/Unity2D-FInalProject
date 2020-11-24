using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject enemy;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    public float timeStop = 10;

    void Update()
    {
        timeStop -= Time.deltaTime;
        if (Time.time > nextSpawn && timeStop > 0)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-6.4f, 6.4f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);

        }
    }
}
