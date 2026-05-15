using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.Rendering;
using System;

public class HoundMasterTarget : HoundMasterBaseStates
{
    private StatVariables stats;
    private GameObject target;
    private GameObject[] AllParty;
    private List<GameObject> ValidTargets = new List<GameObject>();
    private int DamageToBeDelt;
    private int WillCrit;
    private int RandomTarget;
    private float DamageVariance;
    Animator animator;
    public override void EnterState(HoundMasterStateManager HoundMaster)
    {
        animator = HoundMaster.Self.GetComponent<Animator>();
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone = false;
        
        Debug.Log("HoundMaster Entered TArgeting");
        AllParty = GameObject.FindGameObjectsWithTag("PartyMember");
        for (int i = 0; i < AllParty.Length; i++)
        {
            if (AllParty[i].GetComponent<StatVariables>().IsDead == false && AllParty[i].GetComponent<StatVariables>().IsActive == true)
            {
                ValidTargets.Add(AllParty[i]);
            }
        }

        stats = HoundMaster.Self.GetComponent<StatVariables>();

        if (stats.WhipSlashNext)
        {
            GameObject.Find("Manager").GetComponent<CombatMenuGetter>().Callout.text = ("The hound master does a wide slash");
            animator.Play("HoundMasterSwipe");
            for (int i = 0; i < ValidTargets.Count; i++)
            {
                DamageToBeDelt = (HoundMaster.Self.GetComponent<StatVariables>().NextAttackDamage - ValidTargets[i].GetComponent<StatVariables>().Endurance.Value);
                WillCrit = UnityEngine.Random.Range(0, 100);
                if (HoundMaster.Self.GetComponent<StatVariables>().CritChance.Value >= WillCrit)
                {
                    DamageToBeDelt *= 2;
                }
                ValidTargets[i].GetComponent<StatVariables>().HitPoints -= DamageToBeDelt;
            }
            stats.WhipSlashNext = false;
        }
        else if (stats.WhipComboNext)
        {
            GameObject.Find("Manager").GetComponent<CombatMenuGetter>().Callout.text = ("The hound master uses a whip combo");
            RandomTarget = UnityEngine.Random.Range(0, ValidTargets.Count - 1);
            WillCrit = UnityEngine.Random.Range(0, 100);
            if (ValidTargets[RandomTarget].GetComponent<StatVariables>().IsOnLeft) 
            {
                animator.Play("HoundMasterComboL");
            }
            if (ValidTargets[RandomTarget].GetComponent<StatVariables>().IsOnRight)
            {
                animator.Play("HoundMasterComboR");
            }


            for (int i = 0; i < 3; i++)
            {
                DamageVariance = UnityEngine.Random.Range(0.55f, 0.65f);
                HoundMaster.Self.GetComponent<StatVariables>().NextAttackDamage = (int)Math.Round(((HoundMaster.Self.GetComponent<StatVariables>().Strength.Value * DamageVariance)), 0);
                DamageToBeDelt = (HoundMaster.Self.GetComponent<StatVariables>().NextAttackDamage - ValidTargets[RandomTarget].GetComponent<StatVariables>().Endurance.Value);
                WillCrit = UnityEngine.Random.Range(0, 100);
                if (HoundMaster.Self.GetComponent<StatVariables>().CritChance.Value >= WillCrit)
                {
                    DamageToBeDelt *= 2;
                }
                ValidTargets[RandomTarget].GetComponent<StatVariables>().HitPoints -= DamageToBeDelt;

            }
            stats.WhipComboNext = false;
        }

        ValidTargets.Clear();
    }

    public override void UpdateState(HoundMasterStateManager HoundMaster)
    {
        if (GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone)
        {
            GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone = false;
            HoundMaster.SwitchState(HoundMaster.EndTurn);
        }
    }

    public override void LeaveState(HoundMasterStateManager HoundMaster)
    {

    }
}
