using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject m_RestartButton;
    [SerializeField] private GameObject m_NextButton;
    [SerializeField] private GameObject m_PreviousButton;

    [SerializeField] private GameObject[] m_Model;

    [SerializeField] public GameObject m_Parent;
    [SerializeField] public GameObject m_currentModel;
    [HideInInspector]public int m_CurrentObjectIndex = 0;

    private void Start()
    {
        if (m_CurrentObjectIndex == 0 && m_PreviousButton.activeSelf == true)
        {
            m_PreviousButton.SetActive(false);
        }
        m_currentModel = Instantiate(m_Model[m_CurrentObjectIndex],new Vector3(0,0,0), Quaternion.identity, m_Parent.transform);
    }

    public void NextModel()
    {

        //navigates to the next step
        if (m_CurrentObjectIndex < m_Model.Length - 1)
        {
            Destroy(m_currentModel);
            //m_Model[m_CurrentObjectIndex].SetActive(false);
            m_CurrentObjectIndex += 1;
           m_currentModel = Instantiate(m_Model[m_CurrentObjectIndex],new Vector3(0,0,0), Quaternion.identity, m_Parent.transform);
            //m_Model[m_CurrentObjectIndex].SetActive(true);
        }

        ManageButtonVisibilty();
    }

    public void PreviousModel()
    {
        //navigates to the previous step
        if (m_CurrentObjectIndex != 0)
        {
            //m_Model[m_CurrentObjectIndex].SetActive(false);
            Destroy(m_currentModel);
            m_CurrentObjectIndex -= 1;
            m_currentModel = Instantiate(m_Model[m_CurrentObjectIndex],new Vector3(0,0,0), Quaternion.identity, m_Parent.transform);
            //m_Model[m_CurrentObjectIndex].SetActive(true);
        }

        ManageButtonVisibilty();
    }

    private void ManageButtonVisibilty()
    {
        //enables and disables previous button when on first step
        if (m_PreviousButton.activeSelf == false && m_CurrentObjectIndex != 0)
        {
            m_PreviousButton.SetActive(true);
        }
        else if (m_PreviousButton.activeSelf == true && m_CurrentObjectIndex == 0)
        {
            m_PreviousButton.SetActive(false);
        }

        //enables and disables next button when on last step
        if (m_NextButton.activeSelf == false && m_CurrentObjectIndex != m_Model.Length - 1)
        {
            m_NextButton.SetActive(true);
        }
        else if (m_NextButton.activeSelf == true && m_CurrentObjectIndex == m_Model.Length - 1)
        {
            m_NextButton.SetActive(false);
        }
    }
}