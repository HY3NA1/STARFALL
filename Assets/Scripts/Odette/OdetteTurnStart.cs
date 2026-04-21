using UnityEngine;

public class OdetteTurnStart : OdetteBaseStates
{
    Animator CameraAnimator;
    StatVariables stats;
    GameObject CombatMenu;
    GameObject CameraHolder;

    public override void EnterState(OdetteStateManager Odette)
    {
        CameraAnimator = GameObject.Find("CameraMain").GetComponent<Animator>();
        CameraHolder = GameObject.Find("CameraMain");
        stats = GameObject.Find("Eitan").GetComponent<StatVariables>();
        if (stats.IsOnLeft)
        {
            CameraAnimator.Play("CameraAnimationLeftTurn");
            CameraHolder.transform.Translate(CameraHolder.GetComponent<CoordinateHolder>().LeftCoord);
            CameraHolder.transform.Rotate(CameraHolder.GetComponent<CoordinateHolder>().LeftRotation);
        }
        else if (stats.IsOnRight)
        {
            CameraAnimator.Play("CameraAnimationRightTurn");
            CameraHolder.transform.Translate(CameraHolder.GetComponent<CoordinateHolder>().RightCoord);
            CameraHolder.transform.Rotate(CameraHolder.GetComponent<CoordinateHolder>().RightRotation);

        }
        CombatMenu = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().CombatMenu;
        CombatMenu.SetActive(true);
        Debug.Log("Odette's Turn");
        Odette.SwitchState(Odette.SelectAction);
    }

    public override void UpdateState(OdetteStateManager Odette)
    {

    }

    public override void LeaveState(OdetteStateManager Odette)
    {

    }
}
