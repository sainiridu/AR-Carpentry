using UnityEngine;

public class MoveHammerToNextNail : MonoBehaviour
{
    public GameObject[] hammers;

    public GameObject finishCanvas;

    [HideInInspector] public int hammerIndex = 0;
    [HideInInspector] public bool maxHitsReached;

    public void MoveToNextHammer()
    {


        if(hammerIndex == hammers.Length -1)
        {
            finishCanvas.SetActive(true);
        }
        if (hammerIndex < hammers.Length - 1)
        {
            hammerIndex++;
            hammers[hammerIndex].SetActive(true);

        }
    }
}
