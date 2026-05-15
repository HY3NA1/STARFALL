using System.Text;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class HoundMasterSelectAction : HoundMasterBaseStates

{
    private StatVariables stats;
    private int RandomChoice;
    public override void EnterState(HoundMasterStateManager HoundMaster)
    {
        stats = HoundMaster.Self.GetComponent<StatVariables>();
        if (HoundMaster.Hound1.GetComponent<StatVariables>().IsDead && HoundMaster.Hound2.GetComponent<StatVariables>().IsDead)
        {
            Debug.Log("Phase2 True");
            stats.PhaseTwo = true;
        }
        if (!stats.PhaseTwo) 
        {
            
            if (stats.HitPoints < (stats.Vitality.Value * 0.5) && (!HoundMaster.Hound1.GetComponent<StatVariables>().IsDead || !HoundMaster.Hound2.GetComponent<StatVariables>().IsDead))
            {
                Debug.Log("Draining");
                stats.TurnsRemaining--;
                HoundMaster.SwitchState(HoundMaster.Drain);
            }
            else if (stats.TurnsRemaining == 0)
            {
                Debug.Log("Applying Buffs");
                stats.TurnsRemaining = 3;
                HoundMaster.SwitchState(HoundMaster.Buff);
            }
            else
            {
                Debug.Log("WhipCrack");
                stats.TurnsRemaining--;
                stats.WhipCrackNext = true;
                HoundMaster.SwitchState(HoundMaster.CrackAnim);
            }
        
        }
        else if (stats.PhaseTwo) 
        {
            if (!stats.PhaseTransitionDone) 
            {
                Debug.Log("PhaseTransition");
                HoundMaster.SwitchState(HoundMaster.Transition);
            }
            else
            {
                if (HoundMaster.Eitan.GetComponent<StatVariables>().IsDead || HoundMaster.Odette.GetComponent<StatVariables>().IsDead)
                {
                    Debug.Log("WhipCombo");
                    stats.WhipComboNext = true;
                    HoundMaster.SwitchState(HoundMaster.Target);
                }
                else
                {
                    RandomChoice = UnityEngine.Random.Range(1, 3);
                    if (RandomChoice == 1)
                    {
                        Debug.Log("Slash");
                        stats.WhipSlashNext = true;
                        HoundMaster.SwitchState(HoundMaster.WhipStrike);
                    }
                    else if (RandomChoice == 2)
                    {
                        Debug.Log("WhipCombo");
                        stats.WhipComboNext = true;
                        HoundMaster.SwitchState(HoundMaster.Target);
                    }
                }

            }
        
        }
    }

    public override void UpdateState(HoundMasterStateManager HoundMaster)
    {

    }

    public override void LeaveState(HoundMasterStateManager HoundMaster)
    {

    }
}