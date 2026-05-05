using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EitanTargetSelect : EitanBaseStates
{
    private int WillCrit;
    private int DamageToBeDelt;
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
    public override void EnterState(EitanStateManager Eitan)
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
        stats = GameObject.Find("Eitan").GetComponent<StatVariables>();
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

    public override void UpdateState(EitanStateManager Eitan)
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        if (GameObject.Find("CameraMain").GetComponent<FinishedAnimationChecker>().IsAnimationDone == true)
        {
            GameObject.Find("CameraMain").GetComponent<FinishedAnimationChecker>().IsAnimationDone = false;
            if (GameObject.Find("Eitan").GetComponent<StatVariables>().TargetingAll)
            {
                for (int i = PotentialTargets.Count; i > 0; i--)
                {
                    for (int k = stats.NextAttackHits; k > 0; k--)
                    {
                        DamageToBeDelt = (GameObject.Find("Eitan").GetComponent<StatVariables>().NextAttackDamage - EnemyRight.GetComponent<StatVariables>().Endurance.Value);
                        WillCrit = UnityEngine.Random.Range(0, 100);
                        if (GameObject.Find("Eitan").GetComponent<StatVariables>().CritChance.Value >= WillCrit)
                        {
                            DamageToBeDelt *= 2;
                        }
                        EnemyRight.GetComponent<StatVariables>().HitPoints -= DamageToBeDelt;

                    }
                }
                GameObject.Find("Eitan").GetComponent<StatVariables>().TargetingAll = false;
                Eitan.SwitchState(Eitan.TurnEnd);
            }
            else
            {
                if (RightHolderNeedsActivation)
                {
                    RightHolder.SetActive(true);
                    RightHP.SetActive(true);
                    RightTarget.onClick.AddListener(delegate { HittingRight(Eitan); });
                    myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(RightHolder);
                }
                if (LeftHolderNeedsActivation)
                {
                    LeftHolder.SetActive(true);
                    LeftHP.SetActive(true);
                    LeftTarget.onClick.AddListener(delegate { HittingLeft(Eitan); });
                    myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(LeftHolder);
                }
                if (CenterHolderNeedsActivation)
                {
                    CenterHolder.SetActive(true);
                    CenterHP.SetActive(true);
                    CenterTarget.onClick.AddListener(delegate { HittingCenter(Eitan); });
                    myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(CenterHolder);
                }
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
        CenterHP.SetActive(false);
        LeftHP.SetActive(false);
        RightHP.SetActive(false);
        LeftHolderNeedsActivation = false;
        RightHolderNeedsActivation = false;
        CenterHolderNeedsActivation = false;
        PotentialTargets.Clear();
    }

    private void HittingRight(EitanStateManager Eitan)
    {
        Debug.Log("Damage Right");
        for (int i = stats.NextAttackHits; i > 0; i--)
        {
            DamageToBeDelt = (GameObject.Find("Eitan").GetComponent<StatVariables>().NextAttackDamage - EnemyRight.GetComponent<StatVariables>().Endurance.Value);
            WillCrit = UnityEngine.Random.Range(0, 100);
            if (GameObject.Find("Eitan").GetComponent<StatVariables>().CritChance.Value >= WillCrit)
            {
                DamageToBeDelt *= 2;
            }
            EnemyRight.GetComponent<StatVariables>().HitPoints -= DamageToBeDelt;

        }

        Eitan.SwitchState(Eitan.TurnEnd);
    }
    private void HittingLeft(EitanStateManager Eitan)
    {
        Debug.Log("Damage Left");
        for (int i = stats.NextAttackHits; i > 0; i--)
        {
            DamageToBeDelt = (GameObject.Find("Eitan").GetComponent<StatVariables>().NextAttackDamage - EnemyLeft.GetComponent<StatVariables>().Endurance.Value);
            WillCrit = UnityEngine.Random.Range(0, 100);
            if (GameObject.Find("Eitan").GetComponent<StatVariables>().CritChance.Value >= WillCrit)
            {
                DamageToBeDelt *= 2;
            }
            EnemyLeft.GetComponent<StatVariables>().HitPoints -= DamageToBeDelt;

        }
        Eitan.SwitchState(Eitan.TurnEnd);
    }
    private void HittingCenter(EitanStateManager Eitan)
    {
        Debug.Log("Damage Center");
        for (int i = stats.NextAttackHits; i > 0; i--)
        {
            DamageToBeDelt = (GameObject.Find("Eitan").GetComponent<StatVariables>().NextAttackDamage - EnemyCenter.GetComponent<StatVariables>().Endurance.Value);
            WillCrit = UnityEngine.Random.Range(0, 100);
            if (GameObject.Find("Eitan").GetComponent<StatVariables>().CritChance.Value >= WillCrit)
            {
                DamageToBeDelt *= 2;
            }
            EnemyCenter.GetComponent<StatVariables>().HitPoints -= DamageToBeDelt;

        }
        Eitan.SwitchState(Eitan.TurnEnd);

    }
}
