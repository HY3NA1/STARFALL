using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using System;

public class OdetteUseItem : OdetteBaseStates
{
    private ConsumeableTracker Items;
    private StatVariables variables;
    private GameObject skillmenu;
    private UnityEngine.UI.Button SkillA;
    private UnityEngine.UI.Button SkillB;
    private UnityEngine.UI.Button SkillC;
    private TMP_Text SkillAName;
    private TMP_Text SkillBName;
    private TMP_Text SkillCName;
    private TMP_Text SkillDesc;
    private string skillA;
    private string skillB;
    private string skillC;
    public override void EnterState(OdetteStateManager Odette)
    {

        skillmenu = GameObject.Find("Manager").GetComponent<CombatMenuGetter>().SkillMenu;
        skillmenu.SetActive(true);
        Items = GameObject.Find("Manager").GetComponent<ConsumeableTracker>();
        variables = GameObject.Find("Odette").GetComponent<StatVariables>();
        GameObject myEventSystem = GameObject.Find("EventSystem");
        SkillA = GameObject.Find("SkillSlotA").GetComponent<UnityEngine.UI.Button>();
        SkillB = GameObject.Find("SkillSlotB").GetComponent<UnityEngine.UI.Button>();
        SkillC = GameObject.Find("SkillSlotC").GetComponent<UnityEngine.UI.Button>();
        SkillDesc = GameObject.Find("SkillDesc").GetComponentInChildren<TMP_Text>();
        SkillAName = GameObject.Find("SkillSlotA").GetComponentInChildren<TMP_Text>();
        SkillBName = GameObject.Find("SkillSlotB").GetComponentInChildren<TMP_Text>();
        SkillCName = GameObject.Find("SkillSlotC").GetComponentInChildren<TMP_Text>();
        SkillA.onClick.RemoveAllListeners();
        SkillB.onClick.RemoveAllListeners();
        SkillC.onClick.RemoveAllListeners();

        SkillAName.text = ("Med Injector");
        SkillBName.text = ("Energy Stim");
        SkillCName.text = ("");



        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("SkillSlotA"));




        if (Items.MedInjectNum > 0)
        {
            SkillA.onClick.AddListener(delegate { MedInjector(Odette); });
        }

        if (Items.EnergyStimNum > 0)
        {
            SkillB.onClick.AddListener(delegate { EnergyStim(Odette); });
        }
    }

    public override void UpdateState(OdetteStateManager Odette)
    {
        

        if (GameObject.Find("SkillSlotA").GetComponent<SkillAListener>().ASelected)
        {
            Debug.Log("Aslse");
            SkillDesc.text = ("Remaining: " + Items.MedInjectNum + "\n \n Heals 50% of max health");
        }
        else if (GameObject.Find("SkillSlotB").GetComponent<SkillBListener>().BSelected)
        {
            Debug.Log("Bslse");
            SkillDesc.text = ("Remaining: " + Items.EnergyStimNum + "\n \n Gain 5 energy points");
        }
        else if (GameObject.Find("SkillSlotC").GetComponent<SkillCListener>().CSelected)
        {
            Debug.Log("Cslse");
            SkillDesc.text = ("");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Odette.SwitchState(Odette.SelectAction);
        }

    }

    public override void LeaveState(OdetteStateManager Odette)
    {
        skillmenu.SetActive(false);
        SkillA.onClick.RemoveAllListeners();
        SkillB.onClick.RemoveAllListeners();
        SkillC.onClick.RemoveAllListeners();
    }

    private void MedInjector(OdetteStateManager Odette)
    {
        variables.HitPoints += (int)Math.Round((variables.Vitality.Value * 0.5), 0);
        Items.MedInjectNum--;
        Odette.SwitchState(Odette.TurnEnd);
    }

    private void EnergyStim(OdetteStateManager Odette)
    {
        variables.CurrentEnergy += 5;
        Items.EnergyStimNum--;
        Odette.SwitchState(Odette.TurnEnd);
    }

}