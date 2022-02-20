using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCursor : MonoBehaviour
{


    public GameObject objectToPlace;

    public GameObject spawnedModel;
    public ARRaycastManager raycastManager;

    public bool alreadySpawned = false;



    //public GameObject ui;

    //public bool useCursor = true;


    void Update()
    {


        //Model Spawning

        if (alreadySpawned && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {


            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            raycastManager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
            if (hits.Count > 0)
            {
                 if (spawnedModel != null)
                {
                    Destroy(spawnedModel);
                     spawnedModel = GameObject.Instantiate(objectToPlace, hits[0].pose.position, hits[0].pose.rotation);
                 }
                else
                {
                spawnedModel = GameObject.Instantiate(objectToPlace, hits[0].pose.position, hits[0].pose.rotation);
                
                //}


            }
        }
    }
}
}



