using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerNail : MonoBehaviour
{
    private GameObject parentObject;
    public int hits = 0;

    private void Start()
    {
        parentObject = this.transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hammer") && hits < 15)
        {
            hits++;
            
            parentObject.transform.position = Vector3.MoveTowards(parentObject.transform.position, new Vector3(parentObject.transform.position.x, parentObject.transform.position.y - 1, parentObject.transform.position.z), 0.015f);
        }
    }
    
}
