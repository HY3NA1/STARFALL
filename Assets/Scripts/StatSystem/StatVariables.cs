using UnityEngine;

public class StatVariables : MonoBehaviour
{

    
    public bool IsTurn = false;
    public bool IsDead = false;
    public int HitPoints;
    public CharStat Vitality;
    public CharStat Strength;
    public CharStat Endurance;
    public CharStat Agility;
    public CharStat CritChance;
    public int NextAttackDamage;
    public int NextAttackHits;

    //PartyMember Only
    public bool IsActive;
    public bool IsOnRight;
    public bool IsOnLeft;
    public int HealthLost = 0;
    public int CurrentEnergy;
    public CharStat StartingEnergy;
    public CharStat EnergyOnTurnStart;
    public CharStat EnergyOnBaseAttack;
    public bool TargetingAll = false;


    //Enemy Only
    public bool IsTargetLeft;
    public bool IsTargetRight;
    public bool IsTargetCenter;

    void Start()
    {
        HitPoints = Vitality.Value;
        HitPoints -= HealthLost;
        CurrentEnergy = StartingEnergy.Value;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vitality.Value < HitPoints) 
        {
            HitPoints = Vitality.Value;
        }
        if (HitPoints <= 0) 
        { 
            IsDead = true;
        }

        HealthLost = Vitality.Value - HitPoints;
    }
}
