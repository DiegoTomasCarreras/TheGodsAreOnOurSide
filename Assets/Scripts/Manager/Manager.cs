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

    public Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer -= Time.deltaTime;
        if (nemActivated == true && currentTimer<=0) //este codigo de aca se supone que abre un cartel que dice no te alcanza la guita si tratas de comprar cuando no tenes, si no lo uso dsp eliminar
        {
            Destroy(notEnoughMoneyImage);
        }
        moneyText.text = money.ToString();
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
