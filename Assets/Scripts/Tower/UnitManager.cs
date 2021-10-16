using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject selectedUnit;
    public AudioClip clickSound;
    public AudioSource source;
    Manager m;
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
}


