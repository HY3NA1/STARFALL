
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.SceneManagement;

public class WinAndLoss : MonoBehaviour
{
    [SerializeField] GameObject Eitan;
    [SerializeField] GameObject Odette;
    [SerializeField] GameObject HoundA;
    [SerializeField] GameObject HoundB;
    [SerializeField] GameObject HoundMaster;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HoundMaster.GetComponent<StatVariables>().IsDead && HoundA.GetComponent<StatVariables>().IsDead && HoundB.GetComponent<StatVariables>().IsDead) 
        {
            SceneManager.LoadScene("Win");
        }
        else if(Eitan.GetComponent<StatVariables>().IsDead && Odette.GetComponent<StatVariables>().IsDead)
        {
            SceneManager.LoadScene("Loss");
        }
    }
}
