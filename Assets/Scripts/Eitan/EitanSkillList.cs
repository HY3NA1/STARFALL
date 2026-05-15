using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using System;

public class EitanSkillList : MonoBehaviour
{

    StatModifier AdrenalineSpeed = new StatModifier(0.5f, StatModType.PercentAddIncrease, 3);
    StatModifier AdrenalineStrength = new StatModifier(0.5f, StatModType.PercentAddIncrease, 3);
    StatModifier AdrenalineEndurance = new StatModifier(0.5f, StatModType.PercentAddDecrease, 3);
    private float DamageVariance;

    public string AdrenalineSkillDesc = ("Cost: 5 \n \n Increases Self Strength by +50% for 3 turns \n Decreases Self Endurance by -50% for 3 turns");

    public string WideSlashSkillDesc = ("Cost: 3 \n \n Deals low damage to all enemies \n Single hit");

    public string LightspeedSkillDesc = ("Cost: 6 \n \n Deals medium damage to a single enemy \n Increased damage based on speed \n 3 hits");
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AdrenalineSkill()
    {
        gameObject.GetComponent<StatVariables>().CurrentEnergy -= 5;

        GameObject.Find("Eitan").GetComponent<StatVariables>().Strength.RemoveModifier(AdrenalineStrength);
        
        GameObject.Find("Eitan").GetComponent<StatVariables>().Endurance.RemoveModifier(AdrenalineEndurance);
        GameObject.Find("Eitan").GetComponent<StatVariables>().Strength.AddModifier(AdrenalineStrength);
        
        GameObject.Find("Eitan").GetComponent<StatVariables>().Endurance.AddModifier(AdrenalineEndurance);
    }

    public void WideSlashSkill()
    {
        gameObject.GetComponent<StatVariables>().CurrentEnergy -= 3;
        DamageVariance = UnityEngine.Random.Range(0.45f, 0.60f);
        gameObject.GetComponent<StatVariables>().NextAttackDamage = (int)Math.Round((gameObject.GetComponent<StatVariables>().Strength.Value * DamageVariance), 0);
        gameObject.GetComponent<StatVariables>().NextAttackHits = 1;
    }

    public void LightspeedSkill()
    {
        gameObject.GetComponent<StatVariables>().CurrentEnergy -= 6;

        DamageVariance = UnityEngine.Random.Range(1, 1.30f);
        gameObject.GetComponent<StatVariables>().NextAttackDamage = (int)Math.Round(((gameObject.GetComponent<StatVariables>().Strength.Value + gameObject.GetComponent<StatVariables>().Agility.Value) * DamageVariance), 0);
        gameObject.GetComponent<StatVariables>().NextAttackHits = 3;
    }
}
