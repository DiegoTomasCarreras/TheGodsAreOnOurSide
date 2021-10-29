using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWithAnimations : MonoBehaviour
{
    public int currentSelectedLevel;
    public GameObject enemySpawner;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    // Start is called before the first frame update
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
                //aca hacer que el orco se anime
                //aca poner la couroutine para que banque hasta que termine la animacion (que espere 1 seg)
                SceneManager.LoadScene(1);
                break;
            case 2:
                //aca hacer que el orco se anime
                //aca poner la couroutine para que banque hasta que termine la animacion (que espere 1 seg)
                SceneManager.LoadScene(2);
                break;
            case 3:
                //aca hacer que el orco se anime
                //aca poner la couroutine para que banque hasta que termine la animacion (que espere 1 seg)
                SceneManager.LoadScene(3);
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
                //Instantiate(enemy1, enemySpawner.transform.position, enemySpawner.transform.rotation);
                enemy1.SetActive(true);
                enemy2.SetActive(false);
                enemy3.SetActive(false);
                break;
            case 2:
                enemy2.SetActive(true);
                enemy1.SetActive(false);
                enemy3.SetActive(false);
                break;
            case 3:
                enemy3.SetActive(true);
                enemy1.SetActive(false);
                enemy2.SetActive(false);
                break;
        }
    }
}
