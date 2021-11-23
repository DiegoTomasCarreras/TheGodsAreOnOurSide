using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject objectToActivate; //script designed for this to be an enemy spawner
    private float currentTime;
    public float timeToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime>=timeToSpawn)
        {
            objectToActivate.SetActive(true);
        }
    }
}
