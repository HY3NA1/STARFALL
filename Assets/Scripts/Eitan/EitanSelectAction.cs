using System.Diagnostics.Contracts;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class EitanSelectAction : EitanBaseStates
{
    private Button BaseAttackButton;
    public override void EnterState(EitanStateManager Eitan)
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        BaseAttackButton = GameObject.Find("Attack").GetComponent<Button>();
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("Attack"));
        BaseAttackButton.onClick.AddListener(delegate { PerformBaseAttack(Eitan); });

    }

    public override void UpdateState(EitanStateManager Eitan)
    {
        
    }

    public override void LeaveState(EitanStateManager Eitan)
    {
        BaseAttackButton.onClick.RemoveAllListeners();
        GameObject.Find("CombatMenu").SetActive(false);
    }

    private void PerformBaseAttack(EitanStateManager Eitan)
    {
        
        Eitan.SwitchState(Eitan.BaseAttack);
        
        
    }

}
