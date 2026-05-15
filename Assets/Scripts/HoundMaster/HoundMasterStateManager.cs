using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class HoundMasterStateManager : MonoBehaviour
{

    HoundMasterBaseStates CurrentState;
    public GameObject Self;
    public HoundMasterNotTurn NotTurn = new HoundMasterNotTurn();
    public HoundMasterTurnStart TurnStart = new HoundMasterTurnStart();
    public HoundMasterSelectAction SelectAction = new HoundMasterSelectAction();
    public HoundMasterTurnEnd EndTurn = new HoundMasterTurnEnd();
    public HoundMasterWhipCrack WhipCrack = new HoundMasterWhipCrack();
    public HoundMasterDrain Drain = new HoundMasterDrain();
    public HoundMasterBuff Buff = new HoundMasterBuff();
    public HoundMasterTransition Transition = new HoundMasterTransition();
    public HoundMasterWhipStrike WhipStrike = new HoundMasterWhipStrike();
    public HoundMasterWhipCrackAnim CrackAnim = new HoundMasterWhipCrackAnim();
    public HoundMasterTarget Target = new HoundMasterTarget();
    public GameObject Hound1;
    public GameObject Hound2;
    public GameObject Eitan;
    public GameObject Odette;
    

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

    public void SwitchState(HoundMasterBaseStates state)
    {
        CurrentState.LeaveState(this);
        CurrentState = state;
        CurrentState.EnterState(this);
    }

}
