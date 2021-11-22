using System.Collections;
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

    public string path;

    private Manager m;

    public float spawnDelay;
    public float currentSpawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        time += timeDiscountFirstOrc;
        m = FindObjectOfType<Manager>();
        currentSpawnDelay = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpawnDelay -= Time.deltaTime;
        if(currentSpawnDelay>0)
        {
            return;
        }
        if(m.enemiesSpawned>=m.enemyKillsObjective) //if no more enemies to spawn stop spawning
        {
            return;
        }
        time += Time.deltaTime;
        if (time >= spawnTimer)
        {
            enemy.GetComponent<Enemy>().path = path;
            Instantiate(enemy, this.transform.position, this.transform.rotation);
            m.enemiesSpawned += 1;
            time = 0;
            spawnTimer -= spawnTimerDiscounter;
            if (spawnTimer<minSpawnTime)
            {
                spawnTimer = minSpawnTime;
            }
        }
    }
}
