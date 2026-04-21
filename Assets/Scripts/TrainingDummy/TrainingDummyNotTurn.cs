using UnityEngine;

public class TrainingDummyNotTurn : TrainingDummyBaseStates
{
    GameObject ThisCharacter;
    StatVariables StatVariables;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(TrainingDummyStateManager TrainingDummy)
    {
        ThisCharacter = TrainingDummy.Self;
        StatVariables = ThisCharacter.GetComponent<StatVariables>();
    }

    public override void UpdateState(TrainingDummyStateManager TrainingDummy)
    {
        if (StatVariables.IsTurn == true)
        {
            TrainingDummy.SwitchState(TrainingDummy.TurnStart);
        }
    }

    public override void LeaveState(TrainingDummyStateManager TrainingDummy)
    {

    }
}
