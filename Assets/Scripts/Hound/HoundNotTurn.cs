using UnityEngine;

public class HoundNotTurn : HoundBaseStates
{
    GameObject ThisCharacter;
    StatVariables StatVariables;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(HoundStateManager Hound)
    {
        animator = Hound.Self.GetComponent<Animator>();
        animator.Rebind();
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone = false;
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone2 = false;
        ThisCharacter = Hound.Self;
        StatVariables = ThisCharacter.GetComponent<StatVariables>();
    }

    public override void UpdateState(HoundStateManager Hound)
    {
        if (StatVariables.IsTurn == true || StatVariables.WhipCrackTurn == true)
        {
            Hound.SwitchState(Hound.TurnStart);
        }
    }

    public override void LeaveState(HoundStateManager Hound)
    {

    }
}
