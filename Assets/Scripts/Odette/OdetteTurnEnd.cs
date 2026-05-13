using UnityEngine;

public class OdetteTurnEnd : OdetteBaseStates
{
    GameObject ThisCharacter;
    StatVariables StatVariables;
    GameObject CombatMenu;
    GameObject CameraHolder;
    OdetteSkillSelect SkillEnder; 
    public override void EnterState(OdetteStateManager Odette)
    {
        Debug.Log("Odette Turn End");
        ThisCharacter = GameObject.Find("Odette");
        CombatMenu = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().CombatMenu;
        CombatMenu.SetActive(false);
        StatVariables = ThisCharacter.GetComponent<StatVariables>();
        StatVariables.IsTurn = false;
        CameraHolder = GameObject.Find("CameraMain");
        CameraHolder.transform.Translate(CameraHolder.GetComponent<CoordinateHolder>().DefaultCoord);
        CameraHolder.transform.Rotate(CameraHolder.GetComponent<CoordinateHolder>().DefaultRotation);
        StatVariables.Strength.RemoveDurationExpired();
        StatVariables.Agility.RemoveDurationExpired();
        StatVariables.Endurance.RemoveDurationExpired();
        StatVariables.Vitality.RemoveDurationExpired();
        StatVariables.CritChance.RemoveDurationExpired();
        Odette.SwitchState(Odette.NotTurn);
    }

    public override void UpdateState(OdetteStateManager Odette)
    {

    }

    public override void LeaveState(OdetteStateManager Odette)
    {

    }
}
