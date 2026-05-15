using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class HoundTurnStart : HoundBaseStates
{

    StatVariables stats;
    Animator animator;
    public override void EnterState(HoundStateManager Hound)
    {
        
        stats = Hound.Self.GetComponent<StatVariables>();
        Debug.Log("Hound's Turn");
        stats.Strength.DurationTick();
        stats.Agility.DurationTick();
        stats.Endurance.DurationTick();
        stats.Vitality.DurationTick();
        stats.CritChance.DurationTick();
        Hound.SwitchState(Hound.SelectAction);

    }

    public override void UpdateState(HoundStateManager Hound)
    {

    }

    public override void LeaveState(HoundStateManager Hound)
    {

    }
}
