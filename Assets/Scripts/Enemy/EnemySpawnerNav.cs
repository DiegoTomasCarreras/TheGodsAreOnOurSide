using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnerNav : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawner;
    private float time;
    public float spawnTimer;
    public GameObject[] targets;
    private GameObject target;
    private float distance=9999999999999;
    public string path;
    // Start is called before the first frame update
    void Start()
    {
       // float auxDist;
       //for(int c=0;c<targets.Count();c++)
       // {
       //     auxDist= Vector3.Distance(targets[c].transform.position, this.transform.position);
       //     if (distance>auxDist)
       //     {
       //         distance = auxDist;
       //         target = targets[c];
       //     }
       // }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawnTimer)
        {
            GameObject e = Instantiate(enemy, spawner.position, spawner.rotation);
            e.GetComponent<Enemy>().path = path;
            time = 0;
        }
    }
}
