using UnityEngine;

public class HoundMasterNotTurn : HoundMasterBaseStates
{
    GameObject ThisCharacter;
    StatVariables StatVariables;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(HoundMasterStateManager HoundMaster)
    {
        ThisCharacter = HoundMaster.Self;
        StatVariables = ThisCharacter.GetComponent<StatVariables>();
        animator = HoundMaster.Self.GetComponent<Animator>();
        animator.Rebind();
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone = false;
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone2 = false;
    }

    public override void UpdateState(HoundMasterStateManager HoundMaster)
    {
        if (StatVariables.IsTurn == true)
        {
            HoundMaster.SwitchState(HoundMaster.TurnStart);
        }
    }

    public override void LeaveState(HoundMasterStateManager HoundMaster)
    {

    }
}
