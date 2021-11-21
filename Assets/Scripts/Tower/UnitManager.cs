using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject selectedUnit;
    public AudioClip clickSound;
    public AudioSource source;
    Manager m;

    public GameObject buttonCover1;
    public GameObject buttonCover2;
    void Start()
    {
        source = this.GetComponent<AudioSource>();
        m = GameObject.FindObjectOfType<Manager>();
    }

    public void SelectUnitType(GameObject prefab)
    {
        m.debugText.text = "Seleccion de unidad";
        source.PlayOneShot(clickSound);
        selectedUnit = prefab;
        m.debugText.text = "Unidad selected";
    }

    public void SelectUnit1()
    {
        buttonCover1.SetActive(true);
        buttonCover2.SetActive(false);
    }
    public void SelectUnit2()
    {
        buttonCover1.SetActive(false);
        buttonCover2.SetActive(true);
    }
}


