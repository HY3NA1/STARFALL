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
        BaseAttackButton = GameObject.Find("Attack").GetComponent<Button>();
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
