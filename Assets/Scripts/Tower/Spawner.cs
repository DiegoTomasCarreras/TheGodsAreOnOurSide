using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public LayerMask towerSpotLayer;
    Manager m;
    int contadorButtonUp = 0;
    public Camera arCamera;
    // Start is called before the first frame update
    void Start()
    {
        m = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //Vector2  touchPosition = touch.position;
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    TowerSpot tower = hitObject.collider.GetComponent<TowerSpot>();
                    if (tower != null)
                    {
                       // m.debugText.text = "tower no es null";
                        tower.SpawnUnit();
                    }
                }
            }

        }
    }
}



