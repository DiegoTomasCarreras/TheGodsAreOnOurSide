using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    Manager m;
    // Start is called before the first frame update
    void Start()
    {
        m = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
        m.PauseSound();
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        
    }
    public void Resume()
    {
        m.UnPauseSound();
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void BackToMenu()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }
}
