using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class EitanStateManager : MonoBehaviour
{

    EitanBaseStates CurrentState;
    public EitanNotTurn NotTurn = new EitanNotTurn();
    public EitanTurnStart TurnStart = new EitanTurnStart();
    public EitanSelectAction SelectAction = new EitanSelectAction();
    public EitanBaseAttack BaseAttack = new EitanBaseAttack(); 
    public EitanTurnEnd TurnEnd = new EitanTurnEnd();
    public EitanTargetSelect TargetSelect = new EitanTargetSelect();
    public EitanSelectSkill SelectSkill = new EitanSelectSkill();
    public EitanUseItem UseItem = new EitanUseItem();
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

    public void SwitchState(EitanBaseStates state) 
    { 
        CurrentState.LeaveState(this);
        CurrentState = state;
        CurrentState.EnterState(this);
    }

}
