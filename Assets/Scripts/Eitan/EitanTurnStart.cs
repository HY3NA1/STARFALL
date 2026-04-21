using System.Collections;
using UnityEditor;
using UnityEngine;

public class EitanTurnStart : EitanBaseStates
{
    Animator CameraAnimator;
    StatVariables stats;
    GameObject CombatMenu;
    GameObject CameraHolder;

    public override void EnterState(EitanStateManager Eitan)
    {
        CombatMenu = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().CombatMenu;
        CameraAnimator = GameObject.Find("CameraMain").GetComponent<Animator>();
        stats = GameObject.Find("Eitan").GetComponent<StatVariables>();
        CameraHolder = GameObject.Find("CameraMain");
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

        
        

    }

    public override void UpdateState(EitanStateManager Eitan)
    {
        if (GameObject.Find("CameraMain").GetComponent<FinishedAnimationChecker>().IsAnimationDone == true)
        {
            GameObject.Find("CameraMain").GetComponent<FinishedAnimationChecker>().IsAnimationDone = false;
            CombatMenu.SetActive(true);
            Debug.Log("Eitan's Turn");
            Eitan.SwitchState(Eitan.SelectAction);

        }
        
    }
    public override void LeaveState(EitanStateManager Eitan)
    {

    }

}
