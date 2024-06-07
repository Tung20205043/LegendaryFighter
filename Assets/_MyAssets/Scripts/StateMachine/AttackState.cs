using UnityEngine;

public class AttackState : IState {
    public void OnEnter(StateMachine stateMachine) {
        Debug.Log("Enter Attack State");
    }

    public void Update(StateMachine stateMachine) {
        if (Input.GetKeyUp(KeyCode.Space)) {
            stateMachine.SetState(new IdleState());
        }
    }

    public void OnExit() {
        Debug.Log("Exit Attack State");
    }
}
