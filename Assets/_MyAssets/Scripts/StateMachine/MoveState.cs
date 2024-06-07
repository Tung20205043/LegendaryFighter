using UnityEngine;

public class MoveState : IState {
    public void OnEnter(StateMachine stateMachine) {
        Debug.Log("Enter Move State");
    }

    public void Update(StateMachine stateMachine) {
        // Kiểm tra điều kiện để chuyển sang trạng thái Attack
        if (Input.GetKeyDown(KeyCode.Space)) {
            stateMachine.SetState(new AttackState());
        }
        // Kiểm tra điều kiện để chuyển sang trạng thái Idle
        else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) {
            stateMachine.SetState(new IdleState());
        }
        // Logic di chuyển
        else {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            stateMachine.transform.Translate(new Vector3(moveX, moveY, 0) * Time.deltaTime * 5f);
        }
    }

    public void OnExit() {
        Debug.Log("Exit Move State");
    }
}
