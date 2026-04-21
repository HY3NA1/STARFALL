using UnityEngine;

public class OdetteNotTurn : OdetteBaseStates
{
    GameObject ThisCharacter;
    StatVariables StatVariables;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(OdetteStateManager Odette)
    {
        ThisCharacter = GameObject.Find("Odette");
        StatVariables = ThisCharacter.GetComponent<StatVariables>();
    }

    public override void UpdateState(OdetteStateManager Odette)
    {
        if (StatVariables.IsTurn == true)
        {
            Odette.SwitchState(Odette.TurnStart);
        }
    }

    public override void LeaveState(OdetteStateManager Odette)
    {

    }
}
