using UnityEngine;

public abstract class HoundBaseStates
{
    public abstract void EnterState(HoundStateManager Hound);

    public abstract void UpdateState(HoundStateManager Hound);

    public abstract void LeaveState(HoundStateManager Hound);
}
