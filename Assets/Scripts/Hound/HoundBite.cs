using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using System;
using TMPro;

public class HoundBite : HoundBaseStates
{
    private StatVariables stats;
    private float DamageVariance;
    
    public override void EnterState(HoundStateManager Hound)
    {
        stats = Hound.Self.GetComponent<StatVariables>();
        DamageVariance = UnityEngine.Random.Range(0.85f, 1);
        stats.NextAttackDamage = (int)Math.Round((stats.Strength.Value * DamageVariance), 0);
        stats.BiteNext = true;

        

  

        Hound.SwitchState(Hound.Target);
    }

    public override void UpdateState(HoundStateManager Hound)
    {

    }

    public override void LeaveState(HoundStateManager Hound)
    {

    }
}
