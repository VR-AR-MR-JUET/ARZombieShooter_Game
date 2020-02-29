using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Objectspawn : MonoBehaviour
{
    private GameObject indicator;
    //public GameObject zombiespawner;
    private ARRaycastManager aRRaycastManager;
    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        //zombiespawner = transform.GetChild(1).gameObject;
        indicator = transform.GetChild(0).gameObject;
       // zombiespawner.SetActive(false);
        indicator.SetActive(false);
        Debug.Log("working");
    }

    void Update()
    {
        var loc = new Vector2(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        // Debug.Log(hits.Count);
       // aRRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
        aRRaycastManager.Raycast(loc, hits, TrackableType.Planes);
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            Debug.Log(transform.position);
            transform.rotation = hits[0].pose.rotation;
            indicator.SetActive(true);
           // zombiespawner.SetActive(true);
        }
    
    }
}
