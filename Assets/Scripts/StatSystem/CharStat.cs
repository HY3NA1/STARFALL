using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

[Serializable]
public class CharStat
{
    public int BaseValue;
    protected bool needsupdate = true;
    protected int _value;
    protected readonly List<StatModifier> statModifiers;
    protected readonly ReadOnlyCollection<StatModifier> StatModifiers;
    protected float LastBaseValue=float.MinValue;


    public virtual int Value
    {
        get
        {
            if (needsupdate || BaseValue != LastBaseValue)
            {
                LastBaseValue = BaseValue;
                _value = CalculateFinalValue();
                needsupdate = false;
            }
            return _value;
        }

    }
    public CharStat() 
    {
        statModifiers = new List<StatModifier>();
        StatModifiers = statModifiers.AsReadOnly();
    }

    public CharStat(int baseValue) : this() 
    {
        BaseValue = baseValue;
    }

    public virtual void AddModifier(StatModifier mod)
    {
        needsupdate = true;
        statModifiers.Add(mod);
        statModifiers.Sort(CompareModifierOrder);
    }



    public virtual bool RemoveAllModifiersFromSource(object source) 
    {
        bool didremove = false;
        for (int i = statModifiers.Count - 1; i >= 0; i--)
        {
            if (statModifiers[i].Source == source) 
            {
                needsupdate = true;
                didremove = true;
                statModifiers.RemoveAt(i);
            }
        }
        return didremove;
    }

    public virtual void RemoveDurationExpired() 
    {
        for (int i = statModifiers.Count - 1; i >= 0; i--)
        {
            if (statModifiers[i].Duration == 0) 
            { 
                statModifiers.RemoveAt(i);
            }
        }
    }

    public virtual void DurationTick() 
    {
        for (int i = 0; i < statModifiers.Count; i++)
        {
            statModifiers[i].Duration -= 1;
        }
    }


    protected virtual int CompareModifierOrder(StatModifier a, StatModifier b) 
    {
        if (a.Order < b.Order)    
        { 
            return -1;
        }
        else if (a.Order > b.Order)
        { 
            return 1; 
        }
        return 0;
    }

    public virtual bool RemoveModifier(StatModifier mod)
    {
        if (statModifiers.Remove(mod)) 
        { 
            needsupdate = true;
            return true;
        }
        return false;
    }

    protected virtual int CalculateFinalValue()
    {
        float finalvalue = BaseValue;
        for (int i = 0; i < statModifiers.Count; i++)
        {
            StatModifier mod = statModifiers[i];
            if (mod.Type == StatModType.FlatIncrease)
            {
                finalvalue += mod.Value;
            }
            else if (mod.Type == StatModType.FlatDecrease)
            {
                finalvalue -= mod.Value;
            }
            else if (mod.Type == StatModType.PercentMultIncrease)
            {
                finalvalue *= 1 + mod.Value;
            }
            else if (mod.Type == StatModType.PercentMultDecrease)
            {
                finalvalue *= 1 - mod.Value;
            }
            else if (mod.Type == StatModType.PercentAddIncrease) 
            { 
                finalvalue += BaseValue * mod.Value;
            }
            else if (mod.Type == StatModType.PercentAddDecrease)
            {
                finalvalue -= BaseValue * mod.Value;
            }

        }
        return (int)Math.Round(finalvalue, 0);
    }
}
