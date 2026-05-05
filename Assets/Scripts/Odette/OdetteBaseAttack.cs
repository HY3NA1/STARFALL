using UnityEngine;
using System;

public class OdetteBaseAttack : OdetteBaseStates
{
    private StatVariables stats;
    private int WillCrit;
    private float DamageVariance;
    public override void EnterState(OdetteStateManager Odette)
    {
        stats = GameObject.Find("Odette").GetComponent<StatVariables>();
        stats.CurrentEnergy += stats.EnergyOnBaseAttack.Value;
        DamageVariance = UnityEngine.Random.Range(0.85f, 1);
        stats.NextAttackHits = 1;
        stats.NextAttackDamage = (int)Math.Round((stats.Strength.Value * DamageVariance), 0);
        Odette.SwitchState(Odette.TargetSelect);
    }

    public override void UpdateState(OdetteStateManager Odette)
    {

    }

    public override void LeaveState(OdetteStateManager Odette)
    {

    }
}
