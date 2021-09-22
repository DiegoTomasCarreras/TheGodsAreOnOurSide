using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : MonoBehaviour
{
    //la clase va a estar hardcodeada para 1 solo ultimate
    public GameObject specialEffect;
    Manager m;
    public GameObject ultiSpawnPosition;
    public float cooldown;
    public float timePassed;
    void Start()
    {
        m = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > cooldown)
        {
            //boton verde
        }
        else
        {
            //boton rojo
        }
    }
    public void ActivateUlti()
    {
        if(timePassed>cooldown)
        {
            foreach(Enemy e in m.enemies)
            {
                e.SlowDown();
            }
            Instantiate(specialEffect, ultiSpawnPosition.transform.position, ultiSpawnPosition.transform.rotation);
            timePassed = 0;
        }
    }
}
