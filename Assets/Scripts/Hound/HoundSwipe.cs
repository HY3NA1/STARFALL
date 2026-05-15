using System;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class HoundSwipe : HoundBaseStates
{
    private StatVariables stats;
    private float DamageVariance;
    public override void EnterState(HoundStateManager Hound)
    {
        stats = Hound.Self.GetComponent<StatVariables>();
        DamageVariance = UnityEngine.Random.Range(0.50f, 0.65f);
        stats.NextAttackDamage = (int)Math.Round((stats.Strength.Value * DamageVariance), 0);
        stats.SwipeNext = true;
        

        Hound.SwitchState(Hound.Target);
    }

    public override void UpdateState(HoundStateManager Hound)
    {

    }

    public override void LeaveState(HoundStateManager Hound)
    {

    }
}
