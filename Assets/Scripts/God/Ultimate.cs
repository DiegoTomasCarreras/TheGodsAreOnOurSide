using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ultimate : MonoBehaviour
{
    //la clase va a estar hardcodeada para 1 solo ultimate
    public GameObject specialEffect;
    Manager m;
    public GameObject ultiSpawnPosition;
    public float cooldown;
    public float timePassed;
    public float currentCooldown;

    public Image covertorImagen;
    public Text cooldownTimer;

    public AudioClip ultiFreeze;
    public AudioSource source;
    void Start()
    {
        m = FindObjectOfType<Manager>();
        currentCooldown = 0;
        source = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown<=0)
        {
            //boton verde
            covertorImagen.enabled = false;
            cooldownTimer.enabled = false;
        }
        else
        {
            //boton rojo
            cooldownTimer.text =Mathf.RoundToInt( currentCooldown).ToString();
        }
    }
    public void ActivateUlti()
    {
        if(currentCooldown <= 0)
        {
            source.PlayOneShot(ultiFreeze);
            foreach(Enemy e in m.enemies)
            {
                e.SlowDown();
            }
            Instantiate(specialEffect, ultiSpawnPosition.transform.position, ultiSpawnPosition.transform.rotation);
            currentCooldown = cooldown;
            covertorImagen.enabled = true;
            cooldownTimer.enabled = true;
        }
    }
    public void FindUltimateSpawnPosition()
    {
        ultiSpawnPosition = GameObject.Find("UltiSpawner");
    }
}
