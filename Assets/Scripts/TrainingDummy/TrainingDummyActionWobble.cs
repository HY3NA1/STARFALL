using UnityEngine;

public class TrainingDummyActionWobble : TrainingDummyBaseStates
{
    public override void EnterState(TrainingDummyStateManager TrainingDummy)
    {
        Debug.Log("The Training Dummy wobbles slightly.");
        TrainingDummy.SwitchState(TrainingDummy.TurnEnd);
    }

    public override void UpdateState(TrainingDummyStateManager TrainingDummy)
    {

    }

    public override void LeaveState(TrainingDummyStateManager TrainingDummy)
    {

    }
}
