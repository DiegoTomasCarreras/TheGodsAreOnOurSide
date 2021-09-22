using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public float cost;
    public float range;
    public GameObject arrow;
    public float reloadTime;
    public float reloadTimeLeft;
    public float damage;
    public float radius; //para ataques explosivos
    public float recoilTime;
    public float recoilTimeLeft;

    public Transform shooter;

    Animator anim;

    private bool isReloading=false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        Enemy nearestEnemy = null;
        float dist = Mathf.Infinity;

        foreach (Enemy e in enemies)
        {
            if(e.health>0)
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
            return;
        }

        Vector3 dir = nearestEnemy.transform.position - this.transform.position;
        //  Vector3 dir = nearestEnemy.transform.position - baseAcuidar.transform.position;

        Quaternion lookRot = Quaternion.LookRotation(dir);

        this.transform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

        reloadTimeLeft -= Time.deltaTime;
        recoilTimeLeft -= Time.deltaTime;
        if (reloadTimeLeft <= 0 && dir.magnitude <= range&& isReloading==false)
        {
            isReloading = true;
            Shoot(nearestEnemy);
        }
        else if(isReloading==true&&recoilTimeLeft<=0)
        {
            Reload();
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
    void Shoot(Enemy nearestEnemy)
    {
        reloadTimeLeft = reloadTime;
        anim.SetBool("isShooting", true);
        anim.SetBool("isReloading", false);
        //reloadTimeLeft = reloadTime;
        ShootAt(nearestEnemy);
        recoilTimeLeft = recoilTime;
    }
    void Reload()
    {
        anim.SetBool("isShooting", false);
        anim.SetBool("isReloading", true);
        isReloading = false;
    }

    public IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
