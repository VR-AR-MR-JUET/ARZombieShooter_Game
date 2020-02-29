using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    public bool placementpose=false;
    private ARRaycastManager rayManager;
    public GameObject visual;
    public GameObject objectToSpawn;
    private Pose pose;
    private int count = 0;
    void Start()
    {
        rayManager = FindObjectOfType<ARRaycastManager>();

        visual.SetActive(false);
    }

    void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
        placementpose = hits.Count > 0;
        if (placementpose == true)
        {
            var cameraforward = Camera.current.transform.forward;
            var camerabearing = new Vector3(cameraforward.x, 0, cameraforward.z).normalized;
            pose.rotation = Quaternion.LookRotation(camerabearing);

        }
        if (placementpose)
        {
            pose = hits[0].pose;
            print(pose);
           if (!visual.activeInHierarchy)
            {
                visual.SetActive(true);
                if (count == 1)
                {
                    GameObject ob = Instantiate(objectToSpawn, pose.position, pose.rotation);
                }
                
            }
           if(visual.activeInHierarchy)
            {
                visual.transform.SetPositionAndRotation(pose.position, pose.rotation);
            }
            count++;
        }

        /*if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            GameObject ob = Instantiate(objectToSpawn, pose.position, pose.rotation);
        }*/
        
    }
}
