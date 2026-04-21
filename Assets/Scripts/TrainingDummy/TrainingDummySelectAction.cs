using UnityEngine;

public class TrainingDummySelectAction : TrainingDummyBaseStates
{
    public override void EnterState(TrainingDummyStateManager TrainingDummy)
    {
        TrainingDummy.SwitchState(TrainingDummy.Wobble);
    }

    public override void UpdateState(TrainingDummyStateManager TrainingDummy)
    {

    }

    public override void LeaveState(TrainingDummyStateManager TrainingDummy)
    {

    }
}
