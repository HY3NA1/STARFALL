using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEditor;

public class HoundTarget : HoundBaseStates
{
    private StatVariables stats;
    private GameObject target;
    private GameObject[] AllParty;
    private List<GameObject> ValidTargets = new List<GameObject>();
    private int DamageToBeDelt;
    private int WillCrit;
    private int RandomTarget;
    Animator animation;
    public override void EnterState(HoundStateManager Hound)
    {
        Debug.Log("Entering Target Phase");
        AllParty = GameObject.FindGameObjectsWithTag("PartyMember");
        animation = Hound.Self.GetComponent<Animator>();
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone = false;

            for (int i = 0; i < AllParty.Length; i++)
            {
                if (AllParty[i].GetComponent<StatVariables>().IsDead == false && AllParty[i].GetComponent<StatVariables>().IsActive == true)
                {
                    Debug.Log("Ding");
                    ValidTargets.Add(AllParty[i]);
                }
            }   
    

        stats = Hound.Self.GetComponent<StatVariables>();

     
            if (stats.SwipeNext)
            {
            Debug.Log("Swipe");
            GameObject.Find("Manager").GetComponent<CombatMenuGetter>().Callout.text = ("Hound uses a swipe attack");
                if (Hound.Self.GetComponent<StatVariables>().IsTargetLeft)
                {
                    animation.Play("HoundSwipeLeft");
                }
                if (Hound.Self.GetComponent<StatVariables>().IsTargetRight)
                {
                    animation.Play("HoundSwipeRight");
                }

                Debug.Log("Ding2");
                for (int i = 0; i < ValidTargets.Count; i++)
                {
                    DamageToBeDelt = (Hound.Self.GetComponent<StatVariables>().NextAttackDamage - ValidTargets[i].GetComponent<StatVariables>().Endurance.Value);
                    WillCrit = UnityEngine.Random.Range(0, 100);
                    if (Hound.Self.GetComponent<StatVariables>().CritChance.Value >= WillCrit)
                    {
                        DamageToBeDelt *= 2;
                    }
                    ValidTargets[i].GetComponent<StatVariables>().HitPoints -= DamageToBeDelt;
                }
                stats.SwipeNext = false;
            }
            else if (stats.BiteNext)
            {
                Debug.Log("Bite");
                GameObject.Find("Manager").GetComponent<CombatMenuGetter>().Callout.text = ("Hound uses a bite attack");
                Debug.Log("Ding2");
                RandomTarget = UnityEngine.Random.Range(0, ValidTargets.Count - 1);
            

                DamageToBeDelt = (Hound.Self.GetComponent<StatVariables>().NextAttackDamage - ValidTargets[RandomTarget].GetComponent<StatVariables>().Endurance.Value);
                if (DamageToBeDelt < 0) 
                { 
                    DamageToBeDelt = 0;
                }
                WillCrit = UnityEngine.Random.Range(0, 100);
                if (Hound.Self.GetComponent<StatVariables>().CritChance.Value >= WillCrit)
                {
                    DamageToBeDelt *= 2;
                }
                if (Hound.Self.GetComponent<StatVariables>().IsTargetLeft)
                {
                    if (ValidTargets[RandomTarget].GetComponent<StatVariables>().IsOnLeft) 
                    {
                        animation.Play("HoundLeftAttackingLeft");
                    }
                    if (ValidTargets[RandomTarget].GetComponent<StatVariables>().IsOnLeft)
                    {
                        animation.Play("HoundLeftAttackingRight");
                    }
            }
                if (Hound.Self.GetComponent<StatVariables>().IsTargetRight)
                {
                    if (ValidTargets[RandomTarget].GetComponent<StatVariables>().IsOnLeft)
                    {
                        animation.Play("HoundRightAttackingLeft");
                    }
                    if (ValidTargets[RandomTarget].GetComponent<StatVariables>().IsOnLeft)
                    {
                        animation.Play("HoundRightAttackingRight");
                    }
            }
                ValidTargets[RandomTarget].GetComponent<StatVariables>().HitPoints -= DamageToBeDelt;
                stats.BiteNext = false;
            }
            Debug.Log("Leaving Targeting");
            ValidTargets.Clear();
            
        
    }

    public override void UpdateState(HoundStateManager Hound)
    {
        
        if(GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone) 
        {
            GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone = false;
            Debug.Log("AnimCompletionDetected");
            Hound.SwitchState(Hound.TurnEnd);
        }
        
    }

    public override void LeaveState(HoundStateManager Hound)
    {

    }
}
