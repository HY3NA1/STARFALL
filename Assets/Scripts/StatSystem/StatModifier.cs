
public enum StatModType 
{ 
    FlatIncrease = 100,
    FlatDecrease = 200,
    PercentAddIncrease = 300,
    PercentAddDecrease = 400,
    PercentMultIncrease = 500,
    PercentMultDecrease = 600,
    

}
public class StatModifier
{
    public readonly float Value;
    public readonly StatModType Type;
    public readonly int Order;
    public readonly object Source;
    public int Duration;

    public StatModifier(float value, StatModType type, int order, object source, int duration) 
    { 
        Value = value;
        Type = type;
        Order = order;
        Source = source;
        Duration = duration;
    }

    public StatModifier(float value, StatModType type, int duration) : this (value, type, (int)type, null, duration) 
    { 
    
    }
    public StatModifier(float value, StatModType type, int order, int duration) : this(value, type, order, null, duration)
    {

    }
    public StatModifier(float value, StatModType type, object source, int duration) : this(value, type, (int)type, source, duration) 
    {

    }



}
