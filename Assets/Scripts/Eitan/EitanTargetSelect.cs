using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EitanTargetSelect : EitanBaseStates
{
    private GameObject[] EnemyArray;
    private List<GameObject> PotentialTargets = new List<GameObject>();
    private GameObject EnemyCenter;
    private GameObject EnemyRight;
    private GameObject EnemyLeft;
    private GameObject CenterHolder;
    private GameObject RightHolder;
    private GameObject LeftHolder;
    private bool LeftHolderNeedsActivation;
    private bool RightHolderNeedsActivation;
    private bool CenterHolderNeedsActivation;
    private Button CenterTarget;
    private Button LeftTarget;
    private Button RightTarget;
    Animator CameraAnimator;
    StatVariables stats;
    GameObject CombatMenu;
    GameObject CameraHolder;
    public override void EnterState(EitanStateManager Eitan) 
    {
        CenterHolder = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().ReciticleCenter.gameObject;
        LeftHolder = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().ReciticleLeft.gameObject;
        RightHolder = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().ReciticleRight.gameObject;
        CenterTarget = CenterHolder.GetComponent<Button>();
        LeftTarget = LeftHolder.GetComponent<Button>();
        RightTarget = RightHolder.GetComponent<Button>();
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        
        LeftHolderNeedsActivation = false;
        RightHolderNeedsActivation = false;
        CenterHolderNeedsActivation = false;


        CombatMenu = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().CombatMenu;
        CameraAnimator = GameObject.Find("CameraMain").GetComponent<Animator>();
        stats = GameObject.Find("Eitan").GetComponent<StatVariables>();
        CameraHolder = GameObject.Find("CameraMain");
        if (stats.IsOnLeft)
        {
            CameraAnimator.Play("CameraLeftReverse");
            CameraHolder.transform.Translate(CameraHolder.GetComponent<CoordinateHolder>().DefaultCoord);
            CameraHolder.transform.Rotate(CameraHolder.GetComponent<CoordinateHolder>().DefaultRotation);

        }
        /*else if (stats.IsOnRight)
        {
            CameraAnimator.Play("CameraAnimationRightTurn");
            CameraHolder.transform.Translate(CameraHolder.GetComponent<CoordinateHolder>().RightCoord);
            CameraHolder.transform.Rotate(CameraHolder.GetComponent<CoordinateHolder>().RightRotation);

        }*/












        for (int i = 0; i < EnemyArray.Length; i++) 
        {
            if (EnemyArray[i].GetComponent<StatVariables>().IsDead != true)
            {
                PotentialTargets.Add(EnemyArray[i]);
            }
        }
        Debug.Log("There are" + PotentialTargets.Count + "Targets");
        for (int i = 0; i < PotentialTargets.Count; i++)
        {
            if (PotentialTargets[i].GetComponent<StatVariables>().IsTargetLeft) 
            {
                Debug.Log("Target Set To Left");
                EnemyLeft= PotentialTargets[i];
                LeftHolderNeedsActivation = true;
                
                
            }
            else if(PotentialTargets[i].GetComponent<StatVariables>().IsTargetCenter)
            {
                Debug.Log("Target Set To Center");
                EnemyCenter = PotentialTargets[i];
                CenterHolderNeedsActivation = true;
                
                
            }
            else if (PotentialTargets[i].GetComponent<StatVariables>().IsTargetRight)
            {
                Debug.Log("Target Set To Right");
                EnemyRight = PotentialTargets[i];
                RightHolderNeedsActivation = true;

            }
        }
        
        
        

    }

    public override void UpdateState(EitanStateManager Eitan) 
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        if (GameObject.Find("CameraMain").GetComponent<FinishedAnimationChecker>().IsAnimationDone == true)
        {
            GameObject.Find("CameraMain").GetComponent<FinishedAnimationChecker>().IsAnimationDone = false;
            if (RightHolderNeedsActivation) 
            {
                RightHolder.SetActive(true);
                RightTarget.onClick.AddListener(delegate { HittingRight(Eitan); });
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(RightHolder);
            }
            if (LeftHolderNeedsActivation) 
            {
                LeftHolder.SetActive(true);
                LeftTarget.onClick.AddListener(delegate { HittingLeft(Eitan); });
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(LeftHolder);
            }
            if (CenterHolderNeedsActivation) 
            {
                CenterHolder.SetActive(true);
                CenterTarget.onClick.AddListener(delegate { HittingCenter(Eitan); });
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(CenterHolder);
            }
            

        }
    }

    public override void LeaveState(EitanStateManager Eitan) 
    {
        LeftTarget.onClick.RemoveListener(delegate { HittingLeft(Eitan); });
        RightTarget.onClick.RemoveListener(delegate { HittingRight(Eitan); });
        CenterTarget.onClick.RemoveListener(delegate { HittingCenter(Eitan); });
        CenterHolder.SetActive(false);
        LeftHolder.SetActive(false);
        RightHolder.SetActive(false);
    }

    private void HittingRight(EitanStateManager Eitan)
    {
        Debug.Log("Damage Right");
        EnemyRight.GetComponent<StatVariables>().HitPoints = EnemyRight.GetComponent<StatVariables>().HitPoints - (GameObject.Find("Eitan").GetComponent<StatVariables>().NextAttackDamage - EnemyRight.GetComponent<StatVariables>().Endurance.Value);
        Eitan.SwitchState(Eitan.TurnEnd);
    }
    private void HittingLeft(EitanStateManager Eitan)
    {
        Debug.Log("Damage Left");
        EnemyLeft.GetComponent<StatVariables>().HitPoints = EnemyLeft.GetComponent<StatVariables>().HitPoints - (GameObject.Find("Eitan").GetComponent<StatVariables>().NextAttackDamage - EnemyLeft.GetComponent<StatVariables>().Endurance.Value);
        Eitan.SwitchState(Eitan.TurnEnd);
    }
    private void HittingCenter(EitanStateManager Eitan)
    {
        Debug.Log("Damage Center");
        EnemyCenter.GetComponent<StatVariables>().HitPoints = EnemyCenter.GetComponent<StatVariables>().HitPoints - (GameObject.Find("Eitan").GetComponent<StatVariables>().NextAttackDamage - EnemyCenter.GetComponent<StatVariables>().Endurance.Value);
        Eitan.SwitchState(Eitan.TurnEnd);
    }

}
