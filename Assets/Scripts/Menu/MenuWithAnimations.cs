using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWithAnimations : MonoBehaviour
{
    public int currentSelectedLevel;
    //public GameObject enemySpawner;
    public GameObject enemy1;
    public GameObject imgGreen1;
    public Animator enemy1Anim;
    public GameObject enemy2;
    public GameObject imgGreen2;
    public Animator enemy2Anim;
    public GameObject enemy3;
    public Animator enemy3Anim;
    public GameObject imgGreen3;

    public GameObject loadingScreen;
    void Start()
    {
        currentSelectedLevel = 1;
        enemy1.SetActive(true);
        //poner el boton 1 como seleccionado
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel()
    {
        switch (currentSelectedLevel)
        {
            case 1:
                enemy1Anim.SetBool("isSelected",true);
                StartCoroutine(WaitBeforeLoadingScene(2f,1));
                break;
            case 2:
                enemy2Anim.SetBool("isSelected", true);
                StartCoroutine(WaitBeforeLoadingScene(2f, 2));
                break;
            case 3:
                enemy3Anim.SetBool("isSelected", true);
                StartCoroutine(WaitBeforeLoadingScene(2f, 3));
                break;
        }

    }
    public void SelectLevel(int lvl)
    {
        if(currentSelectedLevel==lvl)
        {
            return;
        }
        currentSelectedLevel = lvl;
        switch (lvl)
        {
            case 1:
                imgGreen1.SetActive(true);
                imgGreen2.SetActive(false);
                imgGreen3.SetActive(false);
                enemy1.SetActive(true);
                enemy2.SetActive(false);
                enemy3.SetActive(false);
                break;
            case 2:
                imgGreen2.SetActive(true);
                imgGreen1.SetActive(false);
                imgGreen3.SetActive(false);
                enemy2.SetActive(true);
                enemy1.SetActive(false);
                enemy3.SetActive(false);
                break;
            case 3:
                imgGreen3.SetActive(true);
                imgGreen1.SetActive(false);
                imgGreen2.SetActive(false);
                enemy3.SetActive(true);
                enemy1.SetActive(false);
                enemy2.SetActive(false);
                break;
        }
    }
    IEnumerator WaitBeforeLoadingScene(float secs, int scene)
    {
        yield return new WaitForSeconds(secs);
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(scene);
    }
}
