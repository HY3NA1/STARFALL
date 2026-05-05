using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillBListener : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public bool BSelected = false;

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {

        BSelected = true;
    }
    void IDeselectHandler.OnDeselect(BaseEventData eventData)
    {
        BSelected = false;
    }

}
