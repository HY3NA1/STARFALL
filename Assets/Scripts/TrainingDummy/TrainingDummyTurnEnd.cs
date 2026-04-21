using UnityEngine;

public class TrainingDummyTurnEnd : TrainingDummyBaseStates
{
    GameObject ThisCharacter;
    StatVariables StatVariables;
    public override void EnterState(TrainingDummyStateManager TrainingDummy)
    {
        ThisCharacter = TrainingDummy.Self;
        StatVariables = ThisCharacter.GetComponent<StatVariables>();
        StatVariables.IsTurn = false;
        TrainingDummy.SwitchState(TrainingDummy.NotTurn);
    }

    public override void UpdateState(TrainingDummyStateManager TrainingDummy)
    {

    }

    public override void LeaveState(TrainingDummyStateManager TrainingDummy)
    {

    }
}
