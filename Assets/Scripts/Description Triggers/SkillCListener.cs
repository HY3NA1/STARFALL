using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillCListener : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public bool CSelected = false;

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {

        CSelected = true;
    }
    void IDeselectHandler.OnDeselect(BaseEventData eventData)
    {
        CSelected = false;
    }

}
