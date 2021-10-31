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
    public float currentTimer;
    public float timer;

    public Text moneyText;

    public bool gameStarted = false;
    public Text startingInText;
    public GameObject startingInBackground;
    private float startingInTimer;
    private bool CountDownStarted = false;
    // Start is called before the first frame update
    void Start()
    {

        //startingInText.enabled = false;
        startingInText.gameObject.SetActive(false);
        startingInBackground.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer -= Time.deltaTime;
        moneyText.text = money.ToString();

        //a partir de aca es countdown timer
        if (startingInTimer<=0f&&CountDownStarted==true)
        {
            if(startingInText.enabled==false)
            {
                return;
            }
            else
            {
                startingInText.enabled = false;
                startingInBackground.SetActive(false);
            }
            return;
        }
        if(gameStarted==true&&CountDownStarted==false)
        {
            StartCountDown();
            CountDownStarted = true;
            startingInTimer = 3.5f;
        }
            startingInTimer -= Time.deltaTime;
        if (startingInTimer>=0.7f)
        {
            startingInText.text = "Starting in " + ((int)Mathf.RoundToInt(startingInTimer)).ToString();
        }
        else
        {
            startingInText.text = "Survive";
        }
    }
    public void Pause() //para que las cosas no sigan updateando cambiar todos los update a fixed update
    {

    }
    public void UnPause()
    {

    }
    private void StartCountDown()
    {
        //startingInText.enabled = true;
        startingInText.gameObject.SetActive(true);
        startingInBackground.SetActive(true);
    }
}
