using Unity.Mathematics;
using UnityEngine;

public class HoundSelectAction : HoundBaseStates
{
    GameObject self;
    int Decider;
    public override void EnterState(HoundStateManager Hound)
    {
        if (Hound.Eitan.GetComponent<StatVariables>().IsDead || Hound.Odette.GetComponent<StatVariables>().IsDead) 
        {
            Hound.SwitchState(Hound.Bite);
        }
        else 
        {
            Decider = UnityEngine.Random.Range(1, 3);
            if (Decider == 1) 
            {
                Hound.SwitchState(Hound.Swipe);
            }
            else if  (Decider == 2)
            {
                Hound.SwitchState(Hound.Bite);
            }
        }
    }

    public override void UpdateState(HoundStateManager Hound)
    {

    }

    public override void LeaveState(HoundStateManager Hound)
    {

    }
}
