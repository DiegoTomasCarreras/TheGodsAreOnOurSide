using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject selectedUnit;
    public AudioClip clickSound;
    public AudioClip errorSound;
    public AudioSource source;
    void Start()
    {
        source = this.GetComponent<AudioSource>();
    }

    public void SelectUnitType(GameObject prefab)
    {
        //source.PlayOneShot(clickSound);
        selectedUnit = prefab;
    }
}


