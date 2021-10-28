using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    public Vector3 dstPosition=Vector3.zero;
    public GameObject posLevels;
    public GameObject posTutorial;
    public GameObject posCredits;
    public GameObject posPlay;
    public Camera camera;

    public GameObject panelLevels;
    public GameObject panelMain;
    public GameObject panelCredits;
    public GameObject panelTutorial;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dstPosition!=Vector3.zero)
        {
            transform.position = Vector3.Lerp(transform.position, dstPosition, Time.deltaTime * 2.5f);

            //if (camera.transform.position.z == posLevels.transform.position.z)
            //{
            //    Debug.Log("Entre");
            //    //activa botones de levels
            //    panelCredits.active = false;
            //    panelMain.active = false;
            //    panelTutorial.active = false;

            //    panelLevels.active = true;
            //}
            //if (camera.transform.position.z == posPlay.transform.position.z)
            //{
            //    //activa botones de play
            //}
            //if (camera.transform.position.z == posTutorial.transform.position.z)
            //{
            //    //activa botones de tutorial
            //}
            //if (camera.transform.position.z == posCredits.transform.position.z)
            //{
            //    //activa botones de credits
            //}
        }
    }
    public void MoveTowardsLevels()
    {
        dstPosition = posLevels.transform.position;
        panelCredits.SetActive(false);
        panelMain.SetActive(false);
        panelTutorial.SetActive(false);
        StartCoroutine(ActivateLevelsUI(1));
    }
    public void MoveTowardsPlay()
    {
        dstPosition = posPlay.transform.position;
        panelCredits.SetActive(false);
        panelLevels.SetActive(false);
        panelTutorial.SetActive(false);
        StartCoroutine(ActivateMainUI(1));

    }
    public void MoveTowardsTutorial()
    {
        dstPosition = posTutorial.transform.position;
        panelCredits.SetActive(false);
        panelLevels.SetActive(false);
        panelMain.SetActive(false);
        StartCoroutine(ActivateTutorialUI(1));
    }
    public void MoveTowardsCredits()
    {
        dstPosition = posCredits.transform.position;
        panelMain.SetActive(false);
        panelLevels.SetActive(false);
        panelTutorial.SetActive(false);
        StartCoroutine(ActivateCreditsUI(1));
    }
    IEnumerator ActivateLevelsUI(int secs)
    {
        yield return new WaitForSeconds(secs);
        panelLevels.SetActive(true);
    }
    IEnumerator ActivateMainUI(int secs)
    {
        yield return new WaitForSeconds(secs);
        panelMain.SetActive(true);
    }
    IEnumerator ActivateTutorialUI(int secs)
    {
        yield return new WaitForSeconds(secs);
        panelTutorial.SetActive(true);
    }
    IEnumerator ActivateCreditsUI(int secs)
    {
        yield return new WaitForSeconds(secs);
        panelCredits.SetActive(true);
    }


}
