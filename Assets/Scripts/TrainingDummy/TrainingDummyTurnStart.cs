using UnityEngine;

public class TrainingDummyTurnStart : TrainingDummyBaseStates
{
    public override void EnterState(TrainingDummyStateManager TrainingDummy)
    {
        Debug.Log("TrainingDummy's Turn");
        TrainingDummy.SwitchState(TrainingDummy.SelectAction);
    }

    public override void UpdateState(TrainingDummyStateManager TrainingDummy)
    {

    }

    public override void LeaveState(TrainingDummyStateManager TrainingDummy)
    {

    }
}
