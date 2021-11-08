using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioSource source;
    public GameObject clickSoundPrefab;
    public GameObject cameraLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClickSound()
    {
        source.PlayOneShot(clickSound);
    }
    public void PlayClickSound2()
    {
        Instantiate(clickSoundPrefab, cameraLocation.transform.position, cameraLocation.transform.rotation);
    }
}
