using UnityEngine;

public class IdleState : IState {
    public void OnEnter(StateMachine stateMachine) {
        Debug.Log("Enter Idle State");
    }

    public void Update(StateMachine stateMachine) {
        // Kiểm tra điều kiện để chuyển sang trạng thái Attack
        if (Input.GetKeyDown(KeyCode.Space)) {
            stateMachine.SetState(new AttackState());
        }
        // Kiểm tra điều kiện để chuyển sang trạng thái Move
        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
            stateMachine.SetState(new MoveState());
        }
    }

    public void OnExit() {
        Debug.Log("Exit Idle State");
    }
}
