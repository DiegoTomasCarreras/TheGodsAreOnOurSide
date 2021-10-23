using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnoughMoney : MonoBehaviour
{
    public bool active=false;
    public float timer;
    public float currentTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer -= Time.deltaTime;
        if(active==true)
        {

        }
    }
}
