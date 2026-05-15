using UnityEngine;

public class HoundMasterDrain : HoundMasterBaseStates
{
    Animator animator;
    public override void EnterState(HoundMasterStateManager HoundMaster)
    {
        animator = HoundMaster.Self.GetComponent<Animator>();
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone = false;
        GameObject.Find("Manager").GetComponent<CombatMenuGetter>().Callout.text = ("The hound master drains a hound's HP");
        if (HoundMaster.Hound1.GetComponent<StatVariables>().HitPoints >= HoundMaster.Hound2.GetComponent<StatVariables>().HitPoints) 
        {
            HoundMaster.Self.GetComponent<StatVariables>().HitPoints += HoundMaster.Hound1.GetComponent<StatVariables>().HitPoints;
            HoundMaster.Hound1.GetComponent<StatVariables>().HitPoints = 0;
        }
        else if (HoundMaster.Hound1.GetComponent<StatVariables>().HitPoints < HoundMaster.Hound2.GetComponent<StatVariables>().HitPoints) 
        {
            HoundMaster.Self.GetComponent<StatVariables>().HitPoints += HoundMaster.Hound2.GetComponent<StatVariables>().HitPoints;
            HoundMaster.Hound2.GetComponent<StatVariables>().HitPoints = 0;
        }
        animator.Play("HoundMasterSupport");
      
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
