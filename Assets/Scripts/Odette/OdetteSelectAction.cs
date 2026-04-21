using UnityEngine;
using UnityEngine.UI;
public class OdetteSelectAction : OdetteBaseStates
{
    private Button BaseAttackButton;
    public override void EnterState(OdetteStateManager Odette)
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        BaseAttackButton = GameObject.Find("Attack").GetComponent<Button>();
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("Attack"));
        BaseAttackButton.onClick.AddListener(delegate { PerformBaseAttack(Odette); });
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
}