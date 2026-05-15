using UnityEngine;

public class HoundTurnEnd : HoundBaseStates
{
    GameObject ThisCharacter;
    StatVariables StatVariables;
    public override void EnterState(HoundStateManager Hound)
    {
        ThisCharacter = Hound.Self;
        StatVariables = ThisCharacter.GetComponent<StatVariables>();
        StatVariables.Strength.RemoveDurationExpired();
        StatVariables.Agility.RemoveDurationExpired();
        StatVariables.Endurance.RemoveDurationExpired();
        StatVariables.Vitality.RemoveDurationExpired();
        StatVariables.CritChance.RemoveDurationExpired();
        StatVariables.IsTurn = false;
        StatVariables.WhipCrackTurn = false;
        Hound.SwitchState(Hound.NotTurn);
    }

    public override void UpdateState(HoundStateManager Hound)
    {

    }

    public override void LeaveState(HoundStateManager Hound)
    {

    }
}
