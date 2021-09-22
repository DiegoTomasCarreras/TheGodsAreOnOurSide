using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public float money;
    public Text debugText;
    public List<Enemy> enemies = new List<Enemy>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause() //para que las cosas no sigan updateando cambiar todos los update a fixed update
    {

    }
    public void UnPause()
    {

    }
}
