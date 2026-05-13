using UnityEngine;
using UnityEngine.UI;
public class OdetteSelectAction : OdetteBaseStates
{
    private Button BaseAttackButton;
    private Button SkillButton;
    private Button ItemButton;
    private GameObject CombatMenu;
    public override void EnterState(OdetteStateManager Odette)
    {
        CombatMenu = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().CombatMenu;
        CombatMenu.SetActive(true);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        BaseAttackButton = GameObject.Find("Attack").GetComponent<Button>();
        SkillButton = GameObject.Find("Skill").GetComponent<Button>();
        ItemButton = GameObject.Find("Item").GetComponent<Button>();
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("Attack"));
        BaseAttackButton.onClick.AddListener(delegate { PerformBaseAttack(Odette); });
        SkillButton.onClick.AddListener(delegate { GoToSkills(Odette); });
        ItemButton.onClick.AddListener(delegate { GoToItem(Odette); });
        
        
    }

    public override void UpdateState(OdetteStateManager Odette)
    {

    }

    public override void LeaveState(OdetteStateManager Odette)
    {
        BaseAttackButton.onClick.RemoveAllListeners();
        SkillButton.onClick.RemoveAllListeners();
        ItemButton.onClick.RemoveAllListeners();
        GameObject.Find("CombatMenu").SetActive(false);
    }

    private void PerformBaseAttack(OdetteStateManager Odette)
    {
        Debug.Log("Odette Attacking");
        Odette.SwitchState(Odette.BaseAttack);


    }
    private void GoToSkills(OdetteStateManager Odette)
    {
        Debug.Log("Odette Selecting");
        Odette.SwitchState(Odette.SelectSkill);


    }
    private void GoToItem(OdetteStateManager Odette)
    {
 
        Odette.SwitchState(Odette.UseItem);


    }
}