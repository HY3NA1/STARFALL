using UnityEngine;
using UnityEngine.UI;
public class OdetteSelectAction : OdetteBaseStates
{
    private Button BaseAttackButton;
    private Button SkillButton;
    public override void EnterState(OdetteStateManager Odette)
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        BaseAttackButton = GameObject.Find("Attack").GetComponent<Button>();
        SkillButton = GameObject.Find("Skill").GetComponent<Button>();
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("Attack"));
        BaseAttackButton.onClick.AddListener(delegate { PerformBaseAttack(Odette); });
        SkillButton.onClick.AddListener(delegate { GoToSkills(Odette); });
    }

    public override void UpdateState(OdetteStateManager Odette)
    {

    }

    public override void LeaveState(OdetteStateManager Odette)
    {
        BaseAttackButton.onClick.RemoveAllListeners();
        GameObject.Find("CombatMenu").SetActive(false);
    }

    private void PerformBaseAttack(OdetteStateManager Odette)
    {

        Odette.SwitchState(Odette.BaseAttack);


    }
    private void GoToSkills(OdetteStateManager Odette)
    {

        Odette.SwitchState(Odette.SelectSkill);


    }
}