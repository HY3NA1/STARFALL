using UnityEngine;

public abstract class EitanBaseStates
{
    public abstract void EnterState(EitanStateManager Eitan);

    public abstract void UpdateState(EitanStateManager Eitan);

    public abstract void LeaveState(EitanStateManager Eitan);
}
