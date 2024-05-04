using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController {

    [SerializeField] protected Joystick joyStick = null;
    [SerializeField] protected float moveSpeed;
    protected void Update() {
        Move();
        FaceToEnemy(GameObjectManager.Instance.EnemyObject());
        FlipToEnemy(GameObjectManager.Instance.EnemyObject());
    }
    protected override void Move() {
        Vector3 targetDirection = new Vector3(joyStick.Direction.x, joyStick.Direction.y, 0);
        targetDirection.Normalize();
        Vector3 newPosition = transform.position + targetDirection * moveSpeed * Time.deltaTime;
        newPosition = GameManager.Instance.LimitPosition(newPosition);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * moveSpeed);
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
