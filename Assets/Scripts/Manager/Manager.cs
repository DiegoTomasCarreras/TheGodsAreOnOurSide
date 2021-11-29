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

    public GameObject youLoseScreen;
    public GameObject youWinScreen;
    public int currentEnemyKills;
    public int enemyKillsObjective;
    public int enemiesSpawned;

    public Ultimate u; 
    public GameObject ultimateBlocker;

    AudioSource source;
    public AudioClip backgroundMusic;
    public  AudioSource winAudio;
    public AudioSource loseAudio;

    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        source = this.GetComponent<AudioSource>();
        //startingInText.enabled = false;
        startingInText.gameObject.SetActive(false);
        startingInBackground.SetActive(false);
        Time.timeScale = 1;
        u = FindObjectOfType<Ultimate>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer -= Time.deltaTime;
        moneyText.text = money.ToString();

        if (currentEnemyKills >= enemyKillsObjective&& counter == 0)
        {
            counter++;
            YouWin();
        }

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
            u.FindUltimateSpawnPosition();
            ultimateBlocker.SetActive(false);
            CountDownStarted = true;
            startingInTimer = 3.5f;
            source.PlayOneShot(backgroundMusic);
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
    public void PauseSound() //para que las cosas no sigan updateando cambiar todos los update a fixed update
    {
        source.Pause();
    }
    public void UnPauseSound()
    {
        source.UnPause();
    }
    private void StartCountDown()
    {
        //startingInText.enabled = true;
        startingInText.gameObject.SetActive(true);
        startingInBackground.SetActive(true);
    }

    public void YouLose()
    {
        source.Stop();
        //loseAudio.Play();
        Time.timeScale = 0;
        youLoseScreen.SetActive(true);
    }

    public void YouWin()
    {
        //Time.timeScale = 0;   ESTE 
        //youWinScreen.SetActive(true); Y ESTE SON LOS OG
        //desactivar musica comun
        //
        source.Stop();
        winAudio.Play();
        youWinScreen.SetActive(true);
        StartCoroutine(WaitBeforePausing(3f));

    }

    IEnumerator WaitBeforePausing(float secs)
    {
        yield return new WaitForSeconds(secs);
        Time.timeScale = 0;
    }
}
