using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public float money;
    public Text debugText;
    public List<Enemy> enemies = new List<Enemy>();
    public GameObject notEnoughMoneyImage;
    public bool nemActivated = false;
    public float currentTimer;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer -= Time.deltaTime;
        if (nemActivated == true && currentTimer<=0)
        {
            Destroy(notEnoughMoneyImage);
        }
    }
    public void Pause() //para que las cosas no sigan updateando cambiar todos los update a fixed update
    {

    }
    public void UnPause()
    {

    }
    public void ActivateNotEnoughMoney()
    {
        notEnoughMoneyImage.active = true;
        nemActivated = true;
        currentTimer = timer;
    }
}
