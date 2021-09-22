﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectToSpawn;
    public PlacementManager pcm;
    private bool objectSpawned = false;
    private GameObject spawnedObject;
    public GameObject pcmPointerToDisable; //ya que tengo esto no haria falta buscar el pcm abajo
    public GameObject canvasToDisable;
    // Start is called before the first frame update
    void Start()
    {
        pcm = FindObjectOfType<PlacementManager>();
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began&& objectSpawned==false&&pcm.isDeployable==true)
        {
            spawnedObject = Instantiate(objectToSpawn, pcm.transform.position, pcm.transform.rotation);
            objectSpawned = true;
            
            this.enabled = false;
            Destroy(pcmPointerToDisable);
            Destroy(canvasToDisable);
        }
        else
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && objectSpawned == true&&pcm.isDeployable==true)
            {
                spawnedObject.transform.position = pcm.transform.position;
                spawnedObject.transform.rotation = pcm.transform.rotation;
            }
        }
    }
}
