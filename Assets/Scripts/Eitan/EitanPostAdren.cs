using UnityEngine;

public class EitanPostAdren : EitanBaseStates
{
    GameObject ThisCharacter;
    GameObject CombatMenu;
    StatVariables StatVariables;
    GameObject CameraHolder;
    public override void EnterState(EitanStateManager Eitan)
    {
        
        Eitan.SwitchState(Eitan.TurnEnd);
    }

    public override void UpdateState(EitanStateManager Eitan)
    {

    }

    public override void LeaveState(EitanStateManager Eitan)
    {

    }
}