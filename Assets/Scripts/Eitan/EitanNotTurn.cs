using UnityEngine;

public class EitanNotTurn : EitanBaseStates
{
    GameObject ThisCharacter;
    StatVariables StatVariables;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(EitanStateManager Eitan)
    {
        ThisCharacter = GameObject.Find("Eitan");
        StatVariables = ThisCharacter.GetComponent<StatVariables>();
    }

    public override void UpdateState(EitanStateManager Eitan)
    {
       if (StatVariables.IsTurn == true) 
        {
            Eitan.SwitchState(Eitan.TurnStart);
        }
    }

    public override void LeaveState(EitanStateManager Eitan)
    {

    }
}
