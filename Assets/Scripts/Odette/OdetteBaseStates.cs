using UnityEngine;

public abstract class OdetteBaseStates
{
    public abstract void EnterState(OdetteStateManager Odette);

    public abstract void UpdateState(OdetteStateManager Odette);

    public abstract void LeaveState(OdetteStateManager Odette);
}
