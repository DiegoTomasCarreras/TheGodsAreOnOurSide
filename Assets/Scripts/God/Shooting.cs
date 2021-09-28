using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera arCamera;
    Manager m;
    public int damage;

    public float cooldown;
    public float currentCooldown;
    // Start is called before the first frame update
    void Start()
    {
        m = FindObjectOfType<Manager>();
        currentCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown<=0)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                //Vector2  touchPosition = touch.position;
                if (touch.phase == TouchPhase.Began)
                {
                    //m.debugText.text = "tphase began";
                    Ray ray = arCamera.ScreenPointToRay(touch.position);
                    RaycastHit hitObject;
                    if (Physics.Raycast(ray, out hitObject))
                    {
                        //m.debugText.text = "pase el if con tag enemy";
                        Enemy enemy = hitObject.collider.GetComponent<Enemy>();
                        if (enemy != null)
                        {
                            //m.debugText.text = "enemy no es null";
                            enemy.TakeDamageFromPlayer(damage);
                            //m.debugText.text = "enemigo dañado";
                            currentCooldown = cooldown;
                        }
                    }
                }
            }
        }
    }
}


