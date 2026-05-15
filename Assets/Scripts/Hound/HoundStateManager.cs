using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class HoundStateManager : MonoBehaviour
{

    HoundBaseStates CurrentState;
    public GameObject Eitan;
    public GameObject Odette;
    public GameObject Self;
    public HoundNotTurn NotTurn = new HoundNotTurn();
    public HoundTurnStart TurnStart = new HoundTurnStart();
    public HoundSelectAction SelectAction = new HoundSelectAction();
    public HoundBite Bite = new HoundBite();
    public HoundSwipe Swipe = new HoundSwipe();
    public HoundTarget Target = new HoundTarget();
    public HoundTurnEnd TurnEnd = new HoundTurnEnd();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Self = this.gameObject;
        CurrentState = NotTurn;
        CurrentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void SwitchState(HoundBaseStates state)
    {
        CurrentState.LeaveState(this);
        CurrentState = state;
        CurrentState.EnterState(this);
    }

}
