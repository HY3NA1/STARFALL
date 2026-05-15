using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using System;

public class OdetteSkillList : MonoBehaviour
{

    StatModifier Demoralize = new StatModifier(0.5f, StatModType.PercentAddDecrease, 3);
    private float DamageVariance;
    private GameObject[] debufftargets;
    public string DemoralizeSkillDesc = ("Cost: 4 \n \n Decreases Enemy Strength by -50% fod 3 turns");

    public string EnergyDrainDesc = ("Cost: 1 \n \n Deals very low damage to one enemy \n Gain 3 energy \n Single hit");

    public string SwanSongDesc = ("Cost: 9 \n \n Deals Extreme damage to a all enemies \n Damage greatly increased on low health \n Single hit");
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void DemoralizeSkill()
    {
        debufftargets = GameObject.FindGameObjectsWithTag("Enemy");
        gameObject.GetComponent<StatVariables>().CurrentEnergy -= 4;
        for (int i = 0; i < debufftargets.Length; i++) 
        {
            debufftargets[i].GetComponent<StatVariables>().Strength.RemoveModifier(Demoralize);
            debufftargets[i].GetComponent<StatVariables>().Strength.AddModifier(Demoralize);
        }
        System.Array.Clear(debufftargets, 0, debufftargets.Length);
        
    }

    public void EnergyDrainSkill()
    {
        gameObject.GetComponent<StatVariables>().CurrentEnergy -= 1;
        gameObject.GetComponent<StatVariables>().CurrentEnergy += 3;
        DamageVariance = UnityEngine.Random.Range(0.50f, 0.60f);
        gameObject.GetComponent<StatVariables>().NextAttackDamage = (int)Math.Round((gameObject.GetComponent<StatVariables>().Strength.Value * DamageVariance), 0);
        gameObject.GetComponent<StatVariables>().NextAttackHits = 1;
    }

    public void SwanSongSkill()
    {
        gameObject.GetComponent<StatVariables>().CurrentEnergy -= 9;

        DamageVariance = UnityEngine.Random.Range(2.50f, 2.60f);
        gameObject.GetComponent<StatVariables>().NextAttackDamage = (int)Math.Round(((gameObject.GetComponent<StatVariables>().Strength.Value + gameObject.GetComponent<StatVariables>().Agility.Value) * DamageVariance), 0);
        if ((gameObject.GetComponent<StatVariables>().Vitality.Value * .10f) >= gameObject.GetComponent<StatVariables>().HitPoints) 
        {
            gameObject.GetComponent<StatVariables>().NextAttackDamage *= 3;
        }
        gameObject.GetComponent<StatVariables>().NextAttackHits = 1;
    }
}
