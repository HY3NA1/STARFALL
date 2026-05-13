using UnityEngine;
using System;

public class EitanBaseAttack : EitanBaseStates
{
    private StatVariables stats;
    private int WillCrit;
    private float DamageVariance;
    public override void EnterState(EitanStateManager Eitan)
    {

        stats = GameObject.Find("Eitan").GetComponent<StatVariables>();
        stats.CurrentEnergy += stats.EnergyOnBaseAttack.Value;
        DamageVariance = UnityEngine.Random.Range(0.85f, 1);
        stats.NextAttackHits = 1;
        stats.NextAttackDamage = (int)Math.Round((stats.Strength.Value * DamageVariance), 0);
        Eitan.SwitchState(Eitan.TargetSelect);
    }

    public override void UpdateState(EitanStateManager Eitan)
    {

    }

    public override void LeaveState(EitanStateManager Eitan)
    {

    }
}
