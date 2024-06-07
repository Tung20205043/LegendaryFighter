using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class StateMachine : MonoBehaviour {
    private IState currentState;

    private void Start() {
        SetState(new IdleState());
    }

    private void Update() {
        currentState?.Update(this);
    }

    public void SetState(IState newState) {
        currentState?.OnExit();
        currentState = newState;
        currentState?.OnEnter(this);
    }
}

public interface IState {
    void OnEnter(StateMachine stateMachine);
    void Update(StateMachine stateMachine);
    void OnExit();
}
