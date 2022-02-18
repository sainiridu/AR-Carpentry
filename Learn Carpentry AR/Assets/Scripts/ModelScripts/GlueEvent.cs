using UnityEngine;
public class GlueEvent : MonoBehaviour
{
    [SerializeField] private GameObject wallPanel;
     public void EnableWallPanels()
    {
        if (wallPanel != null)
            if (wallPanel.activeSelf == false)
            {
                wallPanel.SetActive(true);
                this.gameObject.SetActive(false);
            }

    }
}
