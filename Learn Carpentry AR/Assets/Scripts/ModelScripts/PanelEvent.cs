using UnityEngine;

public class PanelEvent : MonoBehaviour
{
    private UiController uiController;

    public void ReplayAnim()
    {
        uiController = GameObject.FindGameObjectWithTag("UIController").gameObject.GetComponent<UiController>();

        uiController.m_CurrentObjectIndex -= 1;

        uiController.NextModel();
       
       
        
    }
}
