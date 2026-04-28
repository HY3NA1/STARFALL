using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class OdetteTargetSelect : OdetteBaseStates
{
    private GameObject[] EnemyArray;
    private List<GameObject> PotentialTargets = new List<GameObject>();
    private GameObject EnemyCenter;
    private GameObject EnemyRight;
    private GameObject EnemyLeft;
    private GameObject CenterHolder;
    private GameObject RightHolder;
    private GameObject LeftHolder;
    private GameObject CenterHP;
    private GameObject RightHP;
    private GameObject LeftHP;
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
    public override void EnterState(OdetteStateManager Odette)
    {
        CenterHolder = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().ReciticleCenter.gameObject;
        LeftHolder = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().ReciticleLeft.gameObject;
        RightHolder = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().ReciticleRight.gameObject;
        CenterHP = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().HPCenter.gameObject;
        LeftHP = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().HPLeft.gameObject;
        RightHP = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().HPRight.gameObject;
        CenterTarget = CenterHolder.GetComponent<Button>();
        LeftTarget = LeftHolder.GetComponent<Button>();
        RightTarget = RightHolder.GetComponent<Button>();
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");

        LeftHolderNeedsActivation = false;
        RightHolderNeedsActivation = false;
        CenterHolderNeedsActivation = false;


        CombatMenu = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().CombatMenu;
        CameraAnimator = GameObject.Find("CameraMain").GetComponent<Animator>();
        stats = GameObject.Find("Odette").GetComponent<StatVariables>();
        CameraHolder = GameObject.Find("CameraMain");
        if (stats.IsOnLeft)
        {
            CameraAnimator.Play("CameraLeftReverse");
            CameraHolder.transform.Translate(CameraHolder.GetComponent<CoordinateHolder>().DefaultCoord);
            CameraHolder.transform.Rotate(CameraHolder.GetComponent<CoordinateHolder>().DefaultRotation);

        }
        else if (stats.IsOnRight)
        {
            CameraAnimator.Play("CameraRightReverse");
            CameraHolder.transform.Translate(CameraHolder.GetComponent<CoordinateHolder>().DefaultCoord);
            CameraHolder.transform.Rotate(CameraHolder.GetComponent<CoordinateHolder>().DefaultRotation);

        }


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
                EnemyLeft = PotentialTargets[i];
                LeftHolderNeedsActivation = true;


            }
            else if (PotentialTargets[i].GetComponent<StatVariables>().IsTargetCenter)
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

    public override void UpdateState(OdetteStateManager Odette)
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        if (GameObject.Find("CameraMain").GetComponent<FinishedAnimationChecker>().IsAnimationDone == true)
        {
            GameObject.Find("CameraMain").GetComponent<FinishedAnimationChecker>().IsAnimationDone = false;
            if (RightHolderNeedsActivation)
            {
                RightHolder.SetActive(true);
                RightHP.SetActive(true);
                RightTarget.onClick.AddListener(delegate { HittingRight(Odette); });
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(RightHolder);
            }
            if (LeftHolderNeedsActivation)
            {
                LeftHolder.SetActive(true);
                LeftHP.SetActive(true);
                LeftTarget.onClick.AddListener(delegate { HittingLeft(Odette); });
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(LeftHolder);
            }
            if (CenterHolderNeedsActivation)
            {
                CenterHolder.SetActive(true);
                CenterHP.SetActive(true);
                CenterTarget.onClick.AddListener(delegate { HittingCenter(Odette); });
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(CenterHolder);
            }


        }
    }

    public override void LeaveState(OdetteStateManager Odette)
    {
        LeftTarget.onClick.RemoveListener(delegate { HittingLeft(Odette); });
        RightTarget.onClick.RemoveListener(delegate { HittingRight(Odette); });
        CenterTarget.onClick.RemoveListener(delegate { HittingCenter(Odette); });
        CenterHolder.SetActive(false);
        LeftHolder.SetActive(false);
        RightHolder.SetActive(false);
        CenterHP.SetActive(false);
        LeftHP.SetActive(false);
        RightHP.SetActive(false);
        LeftHolderNeedsActivation = false;
        RightHolderNeedsActivation = false;
        CenterHolderNeedsActivation = false;
        PotentialTargets.Clear();
    }

    private void HittingRight(OdetteStateManager Odette)
    {
        Debug.Log("Damage Right");
        EnemyRight.GetComponent<StatVariables>().HitPoints = EnemyRight.GetComponent<StatVariables>().HitPoints - (GameObject.Find("Odette").GetComponent<StatVariables>().NextAttackDamage - EnemyRight.GetComponent<StatVariables>().Endurance.Value);
        Odette.SwitchState(Odette.TurnEnd);
    }
    private void HittingLeft(OdetteStateManager Odette)
    {
        Debug.Log("Damage Left");
        EnemyLeft.GetComponent<StatVariables>().HitPoints = EnemyLeft.GetComponent<StatVariables>().HitPoints - (GameObject.Find("Odette").GetComponent<StatVariables>().NextAttackDamage - EnemyLeft.GetComponent<StatVariables>().Endurance.Value);
        Odette.SwitchState(Odette.TurnEnd);
    }
    private void HittingCenter(OdetteStateManager Odette)
    {
        Debug.Log("Damage Center");
        EnemyCenter.GetComponent<StatVariables>().HitPoints = EnemyCenter.GetComponent<StatVariables>().HitPoints - (GameObject.Find("Odette").GetComponent<StatVariables>().NextAttackDamage - EnemyCenter.GetComponent<StatVariables>().Endurance.Value);
        Odette.SwitchState(Odette.TurnEnd);
    }

}
