using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherWithAnim : MonoBehaviour
{
    public float cost;
    public float range;
    public GameObject arrow;
    public float damage;
    public float radius; //para ataques explosivos

    public Transform shooter;

    Animator anim;

    public bool isReloading = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Enemy nearestEnemy = CalculateNearestEnemy();
        if(nearestEnemy!=null)
        {
            Vector3 dir = nearestEnemy.transform.position - this.transform.position;

            Quaternion lookRot = Quaternion.LookRotation(dir);

            this.transform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

            if (dir.magnitude <= range && isReloading == false)
            {
                ExecuteShootAnimation();
            }
        }

    }
    void ShootAt(Enemy e)
    {
        GameObject arrowGO = (GameObject)Instantiate(arrow, shooter.transform.position, shooter.transform.rotation);

        Arrow a = arrowGO.GetComponent<Arrow>();
        a.target = e.transform;
        a.damage = damage;
        a.radius = radius;
    }
    void Shoot()
    {
        Enemy e = CalculateNearestEnemy();
        if(e!=null)
        {
            ShootAt(e);
        }
    }
    void Reload()
    {
        anim.SetBool("isShooting", false);
        anim.SetBool("isReloading", true);
        isReloading = true;
    }
    void ExecuteShootAnimation()
    {
        Debug.Log("Executed shoot animation");
        anim.SetBool("isShooting", true);
        anim.SetBool("isReloading", false);
    }
    public Enemy CalculateNearestEnemy()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        Enemy nearestEnemy = null;
        float dist = Mathf.Infinity;
        foreach (Enemy e in enemies)
        {
            if (e.health > 0)
            {
                float d = Vector3.Distance(this.transform.position, e.transform.position);
                if (nearestEnemy == null || d < dist) //deberia corregir esto para que no puede dispararle si esta demasiado cerca
                {
                    nearestEnemy = e;
                    dist = d;
                }
            }
        }

        if (nearestEnemy == null)
        {
            //Debug.Log("No enemies?");
            return null;
        }
        else
        {
            return nearestEnemy;
        }
    }
    public void Reloaded()
    {
        isReloading = false;
    }
}
