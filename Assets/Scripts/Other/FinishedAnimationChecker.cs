using UnityEngine;

public class FinishedAnimationChecker : MonoBehaviour
{
    public bool IsAnimationDone = false;

    public void AnimationComplete() 
    { 
        IsAnimationDone = true;
    }
}
