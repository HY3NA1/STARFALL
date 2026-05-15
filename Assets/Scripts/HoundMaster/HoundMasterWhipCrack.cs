using UnityEngine;

public class HoundMasterWhipCrack : HoundMasterBaseStates
{

    private int Decider;
    Animator animator;
    public override void EnterState(HoundMasterStateManager HoundMaster)
    {
        Debug.Log("PostAnimDone1");
        if (!HoundMaster.Hound1.GetComponent<StatVariables>().IsDead && !HoundMaster.Hound1.GetComponent<StatVariables>().IsDead)
        {
            Decider = UnityEngine.Random.Range(1, 2);
            if (Decider == 1)
            {
                HoundMaster.Hound1.GetComponent<StatVariables>().WhipCrackTurn = true;
            }
            else if (Decider == 2)
            {
                HoundMaster.Hound2.GetComponent<StatVariables>().WhipCrackTurn = true;
            }
        }
        else if ((HoundMaster.Hound1.GetComponent<StatVariables>().IsDead && !HoundMaster.Hound1.GetComponent<StatVariables>().IsDead))
        {
            HoundMaster.Hound2.GetComponent<StatVariables>().WhipCrackTurn = true;
        }
        else if ((HoundMaster.Hound1.GetComponent<StatVariables>().IsDead && !HoundMaster.Hound1.GetComponent<StatVariables>().IsDead))
        {
            HoundMaster.Hound2.GetComponent<StatVariables>().WhipCrackTurn = true;
        }
        Debug.Log("Waiting For Hound");
        while (HoundMaster.Hound2.GetComponent<StatVariables>().WhipCrackTurn || !HoundMaster.Hound1.GetComponent<StatVariables>().WhipCrackTurn)
        {
            if (!HoundMaster.Hound2.GetComponent<StatVariables>().WhipCrackTurn)
            {
                break;
            }
            else if (!HoundMaster.Hound1.GetComponent<StatVariables>().WhipCrackTurn)
            {
                break;
            }

        }
        Debug.Log("PostAnimDone2");
        Debug.Log("Hound Done");
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone = false;
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone2 = false;
        HoundMaster.SwitchState(HoundMaster.EndTurn);
    }

    public override void UpdateState(HoundMasterStateManager HoundMaster)
    {

      
            
         
        }
       

    public override void LeaveState(HoundMasterStateManager HoundMaster)
    {

    }
}