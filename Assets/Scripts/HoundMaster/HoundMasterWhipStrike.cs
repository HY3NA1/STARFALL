using UnityEngine;
using System;
public class HoundMasterWhipStrike : HoundMasterBaseStates
{
    private float DamageVariance;
    public override void EnterState(HoundMasterStateManager HoundMaster)
    {
        DamageVariance = UnityEngine.Random.Range(0.60f, 0.70f);
        HoundMaster.Self.GetComponent<StatVariables>().NextAttackDamage = (int)Math.Round(((HoundMaster.Self.GetComponent<StatVariables>().Strength.Value * DamageVariance)), 0);
        HoundMaster.SwitchState(HoundMaster.Target);
    }

    public override void UpdateState(HoundMasterStateManager Hound)
    {

    }

    public override void LeaveState(HoundMasterStateManager Hound)
    {

    }
}
