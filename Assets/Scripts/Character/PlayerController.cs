using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController {

    [SerializeField] protected JoystickMovement joystickMovement;
    private void Start()
    {
        joystickMovement.moveDirection.AddListener(Move);
    }
    protected void Update() {
     
    }
    protected override void Move(Vector3 newPosition) {
        characterAnimator.SetMovement(joystickMovement.MoveType());
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * joystickMovement.moveSpeed);
    }
    
    protected override void Attack() {

    }
    protected override void TakeDamage() {
        throw new System.NotImplementedException();
    }
    protected override void Die() {
        throw new System.NotImplementedException();
    }
}
