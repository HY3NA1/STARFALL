using UnityEngine;

public class HoundMasterBuff : HoundMasterBaseStates
{
    private int Decider;
    StatModifier HoundMasterSpeed = new StatModifier(0.5f, StatModType.PercentAddIncrease, 3);
    StatModifier HoundMasterStrength = new StatModifier(0.5f, StatModType.PercentAddIncrease, 3);
    StatModifier HoundMasterEndurance = new StatModifier(0.5f, StatModType.PercentAddDecrease, 3);
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    
    public override void EnterState(HoundMasterStateManager HoundMaster)
    {
        animator = HoundMaster.Self.GetComponent<Animator>();
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone = false;
        Decider = UnityEngine.Random.Range(1, 4);
        if (Decider == 1)
        {
            GameObject.Find("Manager").GetComponent<CombatMenuGetter>().Callout.text = ("The hound master gives the hounds a speed buff");
            HoundMaster.Hound2.GetComponent<StatVariables>().Strength.RemoveModifier(HoundMasterStrength);
            HoundMaster.Hound2.GetComponent<StatVariables>().Agility.RemoveModifier(HoundMasterSpeed);
            HoundMaster.Hound2.GetComponent<StatVariables>().Endurance.RemoveModifier(HoundMasterEndurance);
            HoundMaster.Hound1.GetComponent<StatVariables>().Strength.RemoveModifier(HoundMasterStrength);
            HoundMaster.Hound1.GetComponent<StatVariables>().Agility.RemoveModifier(HoundMasterSpeed);
            HoundMaster.Hound1.GetComponent<StatVariables>().Endurance.RemoveModifier(HoundMasterEndurance);
            HoundMaster.Hound1.GetComponent<StatVariables>().Agility.AddModifier(HoundMasterSpeed);
            HoundMaster.Hound2.GetComponent<StatVariables>().Agility.AddModifier(HoundMasterSpeed);
        }
        else if (Decider == 2)
        {
            GameObject.Find("Manager").GetComponent<CombatMenuGetter>().Callout.text = ("The hound master gives the hounds a defense buff");
            HoundMaster.Hound2.GetComponent<StatVariables>().Strength.RemoveModifier(HoundMasterStrength);
            HoundMaster.Hound2.GetComponent<StatVariables>().Agility.RemoveModifier(HoundMasterSpeed);
            HoundMaster.Hound2.GetComponent<StatVariables>().Endurance.RemoveModifier(HoundMasterEndurance);
            HoundMaster.Hound1.GetComponent<StatVariables>().Strength.RemoveModifier(HoundMasterStrength);
            HoundMaster.Hound1.GetComponent<StatVariables>().Agility.RemoveModifier(HoundMasterSpeed);
            HoundMaster.Hound1.GetComponent<StatVariables>().Endurance.RemoveModifier(HoundMasterEndurance);
            HoundMaster.Hound1.GetComponent<StatVariables>().Endurance.AddModifier(HoundMasterEndurance);
            HoundMaster.Hound2.GetComponent<StatVariables>().Endurance.AddModifier(HoundMasterEndurance);
        }
        else if (Decider == 3)
        {
            GameObject.Find("Manager").GetComponent<CombatMenuGetter>().Callout.text = ("The hound master gives the hounds a strength buff");
            HoundMaster.Hound2.GetComponent<StatVariables>().Strength.RemoveModifier(HoundMasterStrength);
            HoundMaster.Hound2.GetComponent<StatVariables>().Agility.RemoveModifier(HoundMasterSpeed);
            HoundMaster.Hound2.GetComponent<StatVariables>().Endurance.RemoveModifier(HoundMasterEndurance);
            HoundMaster.Hound1.GetComponent<StatVariables>().Strength.RemoveModifier(HoundMasterStrength);
            HoundMaster.Hound1.GetComponent<StatVariables>().Agility.RemoveModifier(HoundMasterSpeed);
            HoundMaster.Hound1.GetComponent<StatVariables>().Endurance.RemoveModifier(HoundMasterEndurance);
            HoundMaster.Hound1.GetComponent<StatVariables>().Strength.AddModifier(HoundMasterStrength);
            HoundMaster.Hound2.GetComponent<StatVariables>().Strength.AddModifier(HoundMasterStrength);
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
