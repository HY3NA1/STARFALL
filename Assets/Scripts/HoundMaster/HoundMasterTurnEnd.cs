using UnityEngine;

public class HoundMasterTurnEnd : HoundMasterBaseStates
{
    GameObject ThisCharacter;
    StatVariables StatVariables;
    public override void EnterState(HoundMasterStateManager HoundMaster)
    {
        ThisCharacter = HoundMaster.Self;
        StatVariables = ThisCharacter.GetComponent<StatVariables>();
        StatVariables.Strength.RemoveDurationExpired();
        StatVariables.Agility.RemoveDurationExpired();
        StatVariables.Endurance.RemoveDurationExpired();
        StatVariables.Vitality.RemoveDurationExpired();
        StatVariables.CritChance.RemoveDurationExpired();
        StatVariables.IsTurn = false;
        StatVariables.WhipCrackTurn = false;
        HoundMaster.SwitchState(HoundMaster.NotTurn);
    }

    public override void UpdateState(HoundMasterStateManager Hound)
    {

    }

    public override void LeaveState(HoundMasterStateManager Hound)
    {

    }
}