using UnityEngine;

public class OdetteSelectAction : OdetteBaseStates
{
    public override void EnterState(OdetteStateManager Odette)
    {
        Odette.SwitchState(Odette.TurnEnd);
    }

    public override void UpdateState(OdetteStateManager Odette)
    {

    }

    public override void LeaveState(OdetteStateManager Odette)
    {

    }
}