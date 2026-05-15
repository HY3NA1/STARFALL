using UnityEngine;
using System;
public class HoundMasterWhipCrackAnim : HoundMasterBaseStates
{
    Animator animator;
    bool animationFinished;
    AnimatorStateInfo animStateInfo;
    public float NTtime;
    public override void EnterState(HoundMasterStateManager HoundMaster)
    {
        
        animator = HoundMaster.Self.GetComponent<Animator>();
        animator.Play("HoundMasterWC");
 
        

        

    }

    public override void UpdateState(HoundMasterStateManager HoundMaster)
    {       
        if (GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone2)
        {
            HoundMaster.SwitchState(HoundMaster.WhipCrack);
        }
    }

    public override void LeaveState(HoundMasterStateManager HoundMaster)
    {

    }
}
