using System.Diagnostics.Contracts;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class EitanSelectAction : EitanBaseStates
{
    private Button BaseAttackButton;
    private Button SkillButton;
    private Button ItemButton;
    private GameObject CombatMenu;
    public override void EnterState(EitanStateManager Eitan)
    {
        CombatMenu = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().CombatMenu;
        CombatMenu.SetActive(true);
        Debug.Log("Selecting Action Eitan");
        GameObject myEventSystem = GameObject.Find("EventSystem");
        BaseAttackButton = GameObject.Find("Attack").GetComponent<Button>();
        SkillButton = GameObject.Find("Skill").GetComponent<Button>();
        ItemButton = GameObject.Find("Item").GetComponent<Button>();
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("Attack"));
        BaseAttackButton.onClick.AddListener(delegate { PerformBaseAttack(Eitan); });
        SkillButton.onClick.AddListener(delegate { GoToSkills(Eitan); });
        ItemButton.onClick.AddListener(delegate { GoToItem(Eitan); });
    }

    public override void UpdateState(EitanStateManager Eitan)
    {
        
    }

    public override void LeaveState(EitanStateManager Eitan)
    {
        BaseAttackButton.onClick.RemoveAllListeners();
        SkillButton.onClick.RemoveAllListeners();
        ItemButton.onClick.RemoveAllListeners();
        GameObject.Find("CombatMenu").SetActive(false);
    }

    private void PerformBaseAttack(EitanStateManager Eitan)
    {
        Debug.Log("Eitan Base Attack Selected");
        Eitan.SwitchState(Eitan.BaseAttack);
        
        
    }

    private void GoToSkills(EitanStateManager Eitan)
    {
        Debug.Log("Eitan Skills Selected");
        Eitan.SwitchState(Eitan.SelectSkill);


    }

    private void GoToItem(EitanStateManager Eitan)
    {
        Eitan.SwitchState(Eitan.UseItem);
    }

}
