using System;
using TMPro;
using Unity.Multiplayer.Center.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class OdetteSkillSelect : OdetteBaseStates
{
    private OdetteSkillList skillList;
    private StatVariables variables;
    private GameObject skillmenu;
    private UnityEngine.UI.Button SkillA;
    private UnityEngine.UI.Button SkillB;
    private UnityEngine.UI.Button SkillC;
    private TMP_Text SkillAName;
    private TMP_Text SkillBName;
    private TMP_Text SkillCName;
    private TMP_Text SkillDesc;
    public override void EnterState(OdetteStateManager Odette)
    {
        skillmenu = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().SkillMenu;
        skillmenu.SetActive(true);
        skillList = GameObject.Find("Odette").GetComponent<OdetteSkillList>();
        variables = GameObject.Find("Odette").GetComponent<StatVariables>();
        GameObject myEventSystem = GameObject.Find("EventSystem");
        SkillA = GameObject.Find("SkillSlotA").GetComponent<UnityEngine.UI.Button>();
        SkillB = GameObject.Find("SkillSlotB").GetComponent<UnityEngine.UI.Button>();
        SkillC = GameObject.Find("SkillSlotC").GetComponent<UnityEngine.UI.Button>();
        SkillDesc = GameObject.Find("SkillDesc").GetComponentInChildren<TMP_Text>();
        SkillAName = GameObject.Find("SkillSlotA").GetComponentInChildren<TMP_Text>();
        SkillBName = GameObject.Find("SkillSlotB").GetComponentInChildren<TMP_Text>();
        SkillCName = GameObject.Find("SkillSlotC").GetComponentInChildren<TMP_Text>();

        SkillAName.text = ("Demoralize");
        SkillBName.text = ("Energy Drain");
        SkillCName.text = ("Swan Song");



        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("SkillSlotA"));




        if (variables.CurrentEnergy >= 4)
        {
            SkillA.onClick.AddListener(delegate { PerformDemoralize(Odette); });
        }

        if (variables.CurrentEnergy >= 1)
        {
            SkillB.onClick.AddListener(delegate { PerformEnergyDrain(Odette); });
        }

        if (variables.CurrentEnergy >= 9)
        {
            SkillC.onClick.AddListener(delegate { PerformSwanSong(Odette); });
        }



    }

    public override void UpdateState(OdetteStateManager Odette)
    {

        if (GameObject.Find("SkillSlotA").GetComponent<SkillAListener>().ASelected)
        {
            Debug.Log("Aslse");
            SkillDesc.text = skillList.DemoralizeSkillDesc;
        }
        else if (GameObject.Find("SkillSlotB").GetComponent<SkillBListener>().BSelected)
        {
            Debug.Log("Bslse");
            SkillDesc.text = skillList.EnergyDrainDesc;
        }
        else if (GameObject.Find("SkillSlotC").GetComponent<SkillCListener>().CSelected)
        {
            Debug.Log("Cslse");
            SkillDesc.text = skillList.SwanSongDesc;
        }
    }

    public override void LeaveState(OdetteStateManager Odette)
    {
        skillmenu.SetActive(false);
        SkillA.onClick.RemoveAllListeners();
        SkillB.onClick.RemoveAllListeners();
        SkillC.onClick.RemoveAllListeners();
    }

    private void PerformDemoralize(OdetteStateManager Odette)
    {
        skillList.DemoralizeSkill();
        Odette.SwitchState(Odette.TurnEnd);
    }

    private void PerformEnergyDrain(OdetteStateManager Odette)
    {
        skillList.EnergyDrainSkill();
        Odette.SwitchState(Odette.TargetSelect);
    }

    private void PerformSwanSong(OdetteStateManager Odette)
    {
        variables.TargetingAll = true;
        skillList.SwanSongSkill();
        Odette.SwitchState(Odette.TargetSelect);
    }
}
