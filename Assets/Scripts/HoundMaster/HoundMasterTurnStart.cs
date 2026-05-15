using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class HoundMasterTurnStart : HoundMasterBaseStates
{

    StatVariables stats;
    public override void EnterState(HoundMasterStateManager HoundMaster)
    {
        stats = HoundMaster.Self.GetComponent<StatVariables>();
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone = false;
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone2 = false;
        Debug.Log("Hound Masters's Turn");
        stats.Strength.DurationTick();
        stats.Agility.DurationTick();
        stats.Endurance.DurationTick();
        stats.Vitality.DurationTick();
        stats.CritChance.DurationTick();
        HoundMaster.SwitchState(HoundMaster.SelectAction);

    }

    public override void UpdateState(HoundMasterStateManager HoundMaster)
    {

    }

    public override void LeaveState(HoundMasterStateManager HoundMaster)
    {

    }
}
