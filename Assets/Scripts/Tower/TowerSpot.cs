using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    //public GameObject base1;
    //public int number;
  //  public AudioClip spawSound;
  //  public AudioSource source;
  //  public AudioClip errorSound;
    Manager m; //para debug
    //deberia haber una variable que diga tipo isOccupied que guarde el objeto torre y dsp si queres podes eliminarlo/upgradearlo y tambien evitas que spawneen otro encima
    void Start()
    {
        // source = this.GetComponent<AudioSource>(); por ahora sin sonido
        m = FindObjectOfType<Manager>(); //para debug
    }
    public void SpawnUnit()
    {
        //m.debugText.text = "En spawn unit";

        UnitManager um = GameObject.FindObjectOfType<UnitManager>();
        if (um.selectedUnit != null)
        {
          //  m.debugText.text = "Unit is not null";
            if (m.money < um.selectedUnit.GetComponent<ArcherWithAnim>().cost)
            {
             //   m.debugText.text = "No alcanza el dinero";
            //    Debug.Log("No alcanza el dinero");
                // source.PlayOneShot(errorSound); por ahora sin sonido
                //sonido no alcanza la moni
                return;
            }

            //source.PlayOneShot(spawSound); por ahora sin sonido
           // m.debugText.text = "Voy a instanciar unidad";
            m.money -= um.selectedUnit.GetComponent<ArcherWithAnim>().cost;
            Instantiate(um.selectedUnit, transform.position, transform.rotation);
          //  m.debugText.text = "Instancie unidad";

            //Destroy(transform.parent.gameObject); esto destruiria el towerspot
        }
    }
    private void Update()
    {
        
    }
}
