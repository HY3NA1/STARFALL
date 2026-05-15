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

    //Hound Only
    public bool BiteNext = false;
    public bool SwipeNext = false;
    public bool WhipCrackTurn = false;

    //Hound Master Only
    public int TurnsRemaining;
    public bool WhipCrackNext = false;
    public bool PhaseTwo = false;
    public bool PhaseTransitionDone = false;
    public bool WhipComboNext = false;
    public bool WhipSlashNext = false;
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
            IsActive = false;
            gameObject.SetActive(false);
        }

        HealthLost = Vitality.Value - HitPoints;
        if (CurrentEnergy > 9) 
        { 
            CurrentEnergy = 9;
        }
    }
}
