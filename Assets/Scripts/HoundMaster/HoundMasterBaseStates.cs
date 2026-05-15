using UnityEngine;

public abstract class HoundMasterBaseStates
{
    public abstract void EnterState(HoundMasterStateManager HoundMaster);

    public abstract void UpdateState(HoundMasterStateManager HoundMaster);

    public abstract void LeaveState(HoundMasterStateManager HoundMaster);
}
