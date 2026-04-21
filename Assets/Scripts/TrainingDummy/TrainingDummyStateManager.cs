using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class TrainingDummyStateManager : MonoBehaviour
{

    TrainingDummyBaseStates CurrentState;
    public GameObject Self;
    public TrainingDummyNotTurn NotTurn = new TrainingDummyNotTurn();
    public TrainingDummyTurnStart TurnStart = new TrainingDummyTurnStart();
    public TrainingDummySelectAction SelectAction = new TrainingDummySelectAction();
    public TrainingDummyActionWobble Wobble = new TrainingDummyActionWobble();
    public TrainingDummyTurnEnd TurnEnd = new TrainingDummyTurnEnd();
    
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

    public void SwitchState(TrainingDummyBaseStates state)
    {
        CurrentState.LeaveState(this);
        CurrentState = state;
        CurrentState.EnterState(this);
    }

}
