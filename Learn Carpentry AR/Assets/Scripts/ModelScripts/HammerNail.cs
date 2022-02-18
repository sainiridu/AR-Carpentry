using UnityEngine;

public class HammerNail : MonoBehaviour
{
    private GameObject parentObject;

    public Vector3 directionToMove;
    public bool maxHitsReached = false;

    public int currentHits = 0;
    public int maxHits = 10;


    private void Start()
    {
        parentObject = this.transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hammer") && currentHits <= maxHits)
        {
            currentHits++;
            
            parentObject.transform.position = Vector3.MoveTowards(parentObject.transform.position, new Vector3(parentObject.transform.position.x + directionToMove.x, parentObject.transform.position.y + directionToMove.y, parentObject.transform.position.z + directionToMove.z), 0.01f);

            if (currentHits > maxHits)
            {
                maxHitsReached = true;
               // other.gameObject.GetComponent<Animator>().StopPlayback();
                other.gameObject.SetActive(false);
            }

        }
        


    }

}
