using UnityEngine;

public class EnemyAnimTrigger : MonoBehaviour
{
    public GameObject BigText;

    public void AnimStart() 
    {
        Debug.Log("AnimationBegun");
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animinprogress = true;
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone = false;
        BigText.SetActive(true);
    }

    public void AnimationComplete()
    {
        Debug.Log("Animation OVer");
        BigText.SetActive(false);
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone = true;
    }

    public void AnimStartWC()
    {
        Debug.Log("AnimationBegun");
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animinprogress = true;
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone2 = false;
        BigText.SetActive(true);
    }

    public void AnimationCompleteWC()
    {
        Debug.Log("Animation OVer");
        BigText.SetActive(false);
        GameObject.Find("Manager").GetComponent<AnimVariableHolder>().animdone2 = true;
    }
}