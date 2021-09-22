using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class PlacementManager : MonoBehaviour
{
    public ARRaycastManager rayCastManager;
    public GameObject Pointer;
    public Text errorText;
    public bool isDeployable=false;
    void Start()
    {
        rayCastManager = FindObjectOfType<ARRaycastManager>();
        Pointer.SetActive(false);
        errorText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hitpoint = new List<ARRaycastHit>();
        rayCastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hitpoint, TrackableType.PlaneWithinPolygon);
        if(hitpoint.Count > 0)
        {
            transform.position = hitpoint[0].pose.position;
            transform.rotation = hitpoint[0].pose.rotation;
            if(!Pointer.activeInHierarchy)
            {
                Pointer.SetActive(true);
                errorText.enabled = false;
                isDeployable = true;
            }
            else
            {
                Pointer.SetActive(false); 
                errorText.enabled = true;  
                isDeployable = false;    
            }
        }
    }
}
