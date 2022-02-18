using UnityEngine;
public class Events : MonoBehaviour
{
    [SerializeField] private GameObject wallPanel;

    public static void LoadStep_0()
    {
        //Instantiate(LoadStep_3)
    }
    public void LoadStep_1()
    {

    }
    public void LoadStep_2()
    {

    }
    public void LoadStep_3()
    {

    }
    public void LoadStep_4()
    {

    }
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
