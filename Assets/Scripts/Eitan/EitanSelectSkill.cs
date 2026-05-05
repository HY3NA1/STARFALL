using TMPro;
using Unity.Multiplayer.Center.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class EitanSelectSkill : EitanBaseStates
{
    private EitanSkillList skillList;
    private StatVariables variables;
    private GameObject skillmenu;
    private UnityEngine.UI.Button SkillA;
    private UnityEngine.UI.Button SkillB;
    private UnityEngine.UI.Button SkillC;
    private TMP_Text SkillAName;
    private TMP_Text SkillBName;
    private TMP_Text SkillCName;
    private TMP_Text SkillDesc;
    public override void EnterState(EitanStateManager Eitan)
    {
        skillmenu.SetActive(true);
        skillList = GameObject.Find("Eitan").GetComponent<EitanSkillList>();
        variables = GameObject.Find("Eitan").GetComponent<StatVariables>();
        GameObject myEventSystem = GameObject.Find("EventSystem");
        SkillA = GameObject.Find("SkillSlotA").GetComponent<UnityEngine.UI.Button>();
        SkillB = GameObject.Find("SkillSlotB").GetComponent<UnityEngine.UI.Button>();
        SkillC = GameObject.Find("SkillSlotC").GetComponent<UnityEngine.UI.Button>();
        SkillDesc = GameObject.Find("SkillDesc").GetComponent<TMP_Text>();
        SkillAName = GameObject.Find("SkillSlotA").GetComponentInChildren<TMP_Text>();
        SkillBName = GameObject.Find("SkillSlotA").GetComponentInChildren<TMP_Text>();
        SkillCName = GameObject.Find("SkillSlotA").GetComponentInChildren<TMP_Text>();

        SkillAName.text = ("Adrenaline");
        SkillBName.text = ("Wide Slash");
        SkillCName.text = ("Lightspeed");

        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("SkillSlotA"));

        if (variables.CurrentEnergy >= 5)
        {
            SkillA.onClick.AddListener(delegate { PerformAdrenaline(Eitan); });
        }


        if (variables.CurrentEnergy >= 3)
        {
            SkillB.onClick.AddListener(delegate { PerformWideSlash(Eitan); });
        }

        if (variables.CurrentEnergy >= 6)
        {
            SkillC.onClick.AddListener(delegate { PerformLightspeed(Eitan); });
        }



    }

    public override void UpdateState(EitanStateManager Eitan)
    {

    }

    public override void LeaveState(EitanStateManager Eitan)
    {
        skillmenu.SetActive(false);
        SkillA.onClick.RemoveAllListeners();
        SkillB.onClick.RemoveAllListeners();
        SkillC.onClick.RemoveAllListeners();
    }

    private void PerformAdrenaline(EitanStateManager Eitan)
    {
        skillList.AdrenalineSkill();
        Eitan.SwitchState(Eitan.TurnEnd);
    }

    private void PerformWideSlash(EitanStateManager Eitan)
    {
        variables.TargetingAll = true;
        skillList.WideSlashSkill();
        Eitan.SwitchState(Eitan.TargetSelect);
    }

    private void PerformLightspeed(EitanStateManager Eitan)
    {
        skillList.LightspeedSkill();
        Eitan.SwitchState(Eitan.TargetSelect);
    }


    private void AdrenalineDesc() 
    {
        SkillDesc.text = skillList.AdrenalineSkillDesc;
        
    }
    private void WideSlashDesc() 
    {
        SkillDesc.text = skillList.WideSlashSkillDesc;
    }
    private void LightspeedDesc()

    {
        SkillDesc.text = skillList.LightspeedSkillDesc;
    }
}
