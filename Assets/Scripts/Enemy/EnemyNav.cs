using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    public float hitPoints;
    public float damage;
    public float attackRate;
    public GameObject target;
    private float distance;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        distance = Vector3.Distance(target.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("CheckDistanceWithTarget", 1.0f, 0.3f);
        if(distance>agent.stoppingDistance)
        {
            agent.SetDestination(target.transform.position);
        }
        else
        {
            //atacar
            Debug.Log("Atacando");
        }
    }
    public void CheckDistanceWithTarget()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);
    }
}
