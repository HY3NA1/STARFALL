using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillAListener : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public bool ASelected = false;
    
    void ISelectHandler.OnSelect(BaseEventData eventData)
    {

        ASelected = true;
    }
    void IDeselectHandler.OnDeselect(BaseEventData eventData)
    {
        ASelected = false;
    }
    
}
