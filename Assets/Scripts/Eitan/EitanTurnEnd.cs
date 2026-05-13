using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EitanTurnEnd : EitanBaseStates
{
    GameObject ThisCharacter;
    GameObject CombatMenu;
    StatVariables StatVariables;
    GameObject CameraHolder;
    public override void EnterState(EitanStateManager Eitan)
    {
        Debug.Log("Eitan Turn End");
        CombatMenu = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().CombatMenu;
        CombatMenu.SetActive(false);
        ThisCharacter = GameObject.Find("Eitan");
        CameraHolder = GameObject.Find("CameraMain");
        CameraHolder.transform.Translate(CameraHolder.GetComponent<CoordinateHolder>().DefaultCoord);
        CameraHolder.transform.Rotate(CameraHolder.GetComponent<CoordinateHolder>().DefaultRotation);
        StatVariables = ThisCharacter.GetComponent<StatVariables>();
        StatVariables.IsTurn = false;
        StatVariables.Strength.RemoveDurationExpired();
        StatVariables.Agility.RemoveDurationExpired();
        StatVariables.Endurance.RemoveDurationExpired();
        StatVariables.Vitality.RemoveDurationExpired();
        StatVariables.CritChance.RemoveDurationExpired();

        Eitan.SwitchState(Eitan.NotTurn);
    }

    public override void UpdateState(EitanStateManager Eitan)
    {

    }

    public override void LeaveState(EitanStateManager Eitan)
    {

    }
}
