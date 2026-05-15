using UnityEngine;

public class HoundMasterTransition : HoundMasterBaseStates
{
    Animator animator;
    public override void EnterState(HoundMasterStateManager HoundMaster)
    {
        animator = HoundMaster.Self.GetComponent<Animator>();
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone = false;
        GameObject.Find("Manager").GetComponent<CombatMenuGetter>().Callout.text = ("The hound master is enraged");
        animator.Play("HoundMasterSupport");
       
    }

    public override void UpdateState(HoundMasterStateManager HoundMaster)
    {
        if (GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone) 
        {
            HoundMaster.Self.GetComponent<StatVariables>().PhaseTransitionDone = true;
            GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone = false;
            HoundMaster.SwitchState(HoundMaster.EndTurn);
        }
    }

    public override void LeaveState(HoundMasterStateManager HoundMaster)
    {

    }
}
