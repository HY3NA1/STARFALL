using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuFunctions : MonoBehaviour
{
    GameObject myEventSystem;
    void Start()
    {
        myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("MenuA"));
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Begin()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
