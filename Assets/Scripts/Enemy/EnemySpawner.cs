﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawner;
    public float time; //hacer privado despues
    public float spawnTimer;
    
    //rework
    public float timeDiscountFirstOrc;
    public float spawnTimerDiscounter;
    public float minSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        time += timeDiscountFirstOrc;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawnTimer)
        {
            GameObject e = Instantiate(enemy, this.transform.position, this.transform.rotation);
            time = 0;
            spawnTimer -= spawnTimerDiscounter;
            if (spawnTimer<minSpawnTime)
            {
                spawnTimer = minSpawnTime;
            }
        }
    }
}
