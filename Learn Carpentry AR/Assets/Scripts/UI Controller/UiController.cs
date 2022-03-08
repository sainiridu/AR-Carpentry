using UnityEngine;
using UnityEngine.SceneManagement;
public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject m_RestartButton;
    [SerializeField] private GameObject m_NextButton;
    [SerializeField] private GameObject m_PreviousButton;

    [SerializeField] private GameObject m_HomeButton;
    [SerializeField] private GameObject m_ResetButton;

    [SerializeField] private GameObject[] m_Model;

    [SerializeField] public GameObject m_Parent;
    [HideInInspector] private GameObject m_currentModel;
    [HideInInspector] public int m_CurrentObjectIndex = 0;

    private void Start()
    {
        if (m_CurrentObjectIndex == 0 && m_PreviousButton.activeSelf == true)
        {
            m_PreviousButton.SetActive(false);
        }
        m_currentModel = Instantiate(m_Model[m_CurrentObjectIndex], m_Parent.transform.position, m_Parent.transform.rotation, m_Parent.transform);
    }

    public void NextModel()
    {

        //navigates to the next step
        if (m_CurrentObjectIndex < m_Model.Length - 1)
        {
            Destroy(m_currentModel);
            //m_Model[m_CurrentObjectIndex].SetActive(false);
            m_CurrentObjectIndex += 1;
            m_currentModel = Instantiate(m_Model[m_CurrentObjectIndex], m_Parent.transform.position, m_Parent.transform.rotation, m_Parent.transform);
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
            m_currentModel = Instantiate(m_Model[m_CurrentObjectIndex], m_Parent.transform.position, m_Parent.transform.rotation, m_Parent.transform);
            //m_Model[m_CurrentObjectIndex].SetActive(true);
        }

        ManageButtonVisibilty();
    }

    public void ReturnToHome()
    {
        SceneManager.LoadScene(0);
        SceneManager.UnloadSceneAsync(1);
    }

    public void StartOverButton()
    {
        SceneManager.LoadScene(1);

    }

    private void ManageButtonVisibilty()
    {
        //enables and disables previous button when on first step
        if (m_PreviousButton.activeSelf == false && m_CurrentObjectIndex != 0)
        {
            m_PreviousButton.SetActive(true);
            m_ResetButton.SetActive(true);
        }
        else if (m_PreviousButton.activeSelf == true && m_CurrentObjectIndex == 0)
        {
            m_ResetButton.SetActive(false);
            m_PreviousButton.SetActive(false);
        }

        //enables and disables next button when on last step
        if (m_NextButton.activeSelf == false && m_CurrentObjectIndex != m_Model.Length - 1)
        {
            m_NextButton.SetActive(true);
            m_HomeButton.SetActive(false);
        }
        else if (m_NextButton.activeSelf == true && m_CurrentObjectIndex == m_Model.Length - 1)
        {
            m_NextButton.SetActive(false);
            m_HomeButton.SetActive(true);
        }
    }
}