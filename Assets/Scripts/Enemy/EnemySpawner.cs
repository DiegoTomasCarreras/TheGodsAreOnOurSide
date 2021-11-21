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
    // Start is called before the first frame update
    void Start()
    {
        time += timeDiscountFirstOrc;
        m = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m.enemiesSpawned>=m.enemyKillsObjective) //if no more enemies to spawn stop spawning
        {
            return;
        }
        time += Time.deltaTime;
        if (time >= spawnTimer)
        {
            GameObject e = Instantiate(enemy, this.transform.position, this.transform.rotation);
            enemy.GetComponent<Enemy>().path = path;
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
