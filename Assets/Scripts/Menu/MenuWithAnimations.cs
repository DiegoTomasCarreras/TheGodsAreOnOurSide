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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel1()
    {
        //aca hacer que el orco se anime
        //aca poner la couroutine para que banque hasta que termine la animacion (que espere 1 seg)
        SceneManager.LoadScene(1);
    }
    public void LoadLevel2()
    {
        //aca hacer que el orco se anime
        //aca poner la couroutine para que banque hasta que termine la animacion (que espere 1 seg)
        SceneManager.LoadScene(2);
    }
    public void LoadLevel3()
    {
        //aca hacer que el orco se anime
        //aca poner la couroutine para que banque hasta que termine la animacion (que espere 1 seg)
        SceneManager.LoadScene(3);
    }
    public void SelectLevel(int lvl)
    {
        if(currentSelectedLevel==lvl)
        {
            return;
        }
        //hacer que el boton de lvl 1 se ponga de color seleccionado
        currentSelectedLevel = lvl;
        if(lvl ==1)
        {
            //Instantiate(enemy1, enemySpawner.transform.position, enemySpawner.transform.rotation);
            enemy1.SetActive(true);
        }
        if(lvl==2)
        {
            enemy2.SetActive(true);
        }
        if(lvl==3)
        {
            enemy3.SetActive(true);
        }
    }
}
