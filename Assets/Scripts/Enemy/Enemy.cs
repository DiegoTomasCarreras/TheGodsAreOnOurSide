using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Enemy : MonoBehaviour
{
    //pathfinding
    GameObject pathGO;
    Transform targetPathNode;
    int pathNodeIndex = 0;

    //stats
    public float health;
    public float damage;
    public float attackRate;
    public float speed;
    //para ralentizar
    private float baseSpeed;
    public float timeSlowedDown;

    public GameObject bloodParticles;
    public GameObject freezeParticles;

    public AudioClip deathSound;
    public AudioClip freezeShot;
    public AudioSource source;

    Animator anim;

    Manager m;

    public bool isDead = false;

    public float price;

    public GameObject explosionEffect;
    void Start()
    {
        pathGO = GameObject.Find("Path1");
        anim = GetComponent<Animator>();
        //establecerle el path en el spawner cuando se spawnea
        m = FindObjectOfType<Manager>();
        m.enemies.Add(this);
        baseSpeed = speed;

        source = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        else
        {

            if (targetPathNode == null)
            {

                GetNextPathNode();
                if (targetPathNode == null)
                {
                   ReachedGoal();
                    return;
                }
            }
            Vector3 dir = targetPathNode.position - this.transform.localPosition;

            float distThisFrame = speed * Time.deltaTime;

            if (dir.magnitude <= distThisFrame)
            {

                targetPathNode = null;
            }
            else
            {

                transform.Translate(dir.normalized * distThisFrame, Space.World);
                //transform.position = Vector3.MoveTowards(transform.position, targetPathNode.position, 0.005f);
                Quaternion targetRotation = Quaternion.LookRotation(dir);
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 5);
                Debug.Log("else");
            }
        }
        timeSlowedDown += Time.deltaTime;
        if(speed!=baseSpeed&&timeSlowedDown>5)
        {
            speed = baseSpeed;
        }
        
    }
    public void Die()
    {
        if(isDead==true)
        {
            return;
        }
        isDead = true;
        anim.SetBool("isDead",true);
        m.enemies.Remove(this);
        source.PlayOneShot(deathSound);
        Object.Destroy(this.gameObject, 4f);
        m.money += price;
        m.currentEnemyKills += 1;
    }
    public void ReachedGoal()
    {
        Debug.Log("reached goal");
        m.YouLose();
        //HACER QUE PERDES
    }
    public void GetNextPathNode()
    {
        if (pathNodeIndex < pathGO.transform.childCount)
        {
            targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
            pathNodeIndex++;
            Debug.Log("getNextNode");
        }
        else
        {
            targetPathNode = null;
            ReachedGoal(); //aca deberia restarle vida al castillo o hacer perder al user
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        Instantiate(bloodParticles, transform.position, transform.rotation);
        if (health <= 0)
        {
            Die();
        }
    }
    public void TakeDamageFromPlayer(float damage)
    {
        health -= damage;
        Instantiate(freezeParticles, transform.position, transform.rotation);
        source.PlayOneShot(freezeShot);
        if (health <= 0)
        {
            Die();
        }
    }
    public void SlowDown()
    {
        speed=speed*0.5f;
        timeSlowedDown = 0;
    }
    public void InstantiateExplosionEffect()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }
}
