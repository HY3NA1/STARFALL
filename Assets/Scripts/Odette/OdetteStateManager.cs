using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class OdetteStateManager : MonoBehaviour
{

    OdetteBaseStates CurrentState;
    public OdetteNotTurn NotTurn = new OdetteNotTurn();
    public OdetteTurnStart TurnStart = new OdetteTurnStart();
    public OdetteSelectAction SelectAction = new OdetteSelectAction();
    public OdetteBaseAttack BaseAttack = new OdetteBaseAttack();
    public OdetteTurnEnd TurnEnd = new OdetteTurnEnd();
    public OdetteTargetSelect TargetSelect = new OdetteTargetSelect();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentState = NotTurn;
        CurrentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void SwitchState(OdetteBaseStates state)
    {
        CurrentState.LeaveState(this);
        CurrentState = state;
        CurrentState.EnterState(this);
    }

}
