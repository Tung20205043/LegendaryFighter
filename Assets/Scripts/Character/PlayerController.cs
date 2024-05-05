using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController {

    [SerializeField] protected JoystickMovement joystickMovement;
    [SerializeField] protected TakeInputButton inputButton;
    [SerializeField] private GameObject auraBuff;
    public float moveSpeed;
    private void Start()
    {
        joystickMovement.moveDirection.AddListener(Move);
        inputButton.isBuffingMana.AddListener(BuffMana);
        inputButton.isDashing.AddListener(Dash);
        characterDash.stopDashing.AddListener(BackToIdle);
    }
    protected void Update() {
        if (CharacterStats.Instance.IsMaxMana()) {
            BuffMana(false);
        }
    }
    protected override void Move(Vector3 targetPosition) {
        if (!CanMove()) return;
        if (targetPosition == default) {
            characterAnimator.SetIdle();
            return;
        }
        Vector3 newPosition = transform.position + targetPosition * moveSpeed * Time.deltaTime;
        newPosition = GameManager.Instance.LimitPosition(newPosition);
        characterAnimator.SetMovement(joystickMovement.MoveType());
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * moveSpeed);
    }
    protected override void BuffMana(bool onBuff) {
        CharacterStats.Instance.ChangeBuffManaState(onBuff);
        characterAnimator.SetBuffMana(onBuff);
        auraBuff.SetActive(onBuff);
    }
    void Dash() {
        characterDash.Dash();
        characterAnimator.SetDash();
    }
    void BackToIdle() {
        characterAnimator.SetIdle();
    }
    protected override void Attack() {

    }
    protected override void TakeDamage() {
        throw new System.NotImplementedException();
    }
    protected override void Die() {
        throw new System.NotImplementedException();
    }
    bool CanMove() { 
        return (characterAnimator.currentAnimationState == AnimationState.Idle ||
            characterAnimator.currentAnimationState == AnimationState.Movement);
    }
}
