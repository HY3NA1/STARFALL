using TMPro;
using UnityEditor.UI;
using UnityEngine;
using System.Collections;

public class EnergyUpdater : MonoBehaviour
{
    private int EnergyValue;
    private StatVariables StatVariables;
    [SerializeField] private  TMP_Text TextL;
    [SerializeField] private TMP_Text TextR;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StatVariables = gameObject.GetComponent<StatVariables>();
        EnergyValue = StatVariables.CurrentEnergy;
        if (StatVariables.IsOnLeft)
        {
            TextL.text = (EnergyValue + "/9");
        }
        if (StatVariables.IsOnRight)
        {
            TextR.text = (EnergyValue + "/9");
        }


    }
}
