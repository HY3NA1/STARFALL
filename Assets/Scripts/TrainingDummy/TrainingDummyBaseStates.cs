using UnityEngine;

public abstract class TrainingDummyBaseStates
{
    public abstract void EnterState(TrainingDummyStateManager TrainingDummy);

    public abstract void UpdateState(TrainingDummyStateManager TrainingDummy);

    public abstract void LeaveState(TrainingDummyStateManager TrainingDummy);
}
