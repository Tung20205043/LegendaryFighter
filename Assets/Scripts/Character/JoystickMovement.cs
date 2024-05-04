using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JoystickMovement : MonoBehaviour
{

    [SerializeField] protected Joystick joyStick = null;
    public float moveSpeed;
    public UnityEvent<Vector3> moveDirection = null;
    private void Awake()
    {
        currentScale = transform.localScale;
    }

    protected void Update()
    {
        if (joyStick.Direction != Vector2.zero)
        {
            UpdateNewPosition();
        }
        FaceToEnemy(GameObjectManager.Instance.EnemyObject());
        FlipToEnemy(GameObjectManager.Instance.EnemyObject());
    }

    public void UpdateNewPosition()
    {
        Vector3 targetDirection = new Vector3(joyStick.Direction.x, joyStick.Direction.y, 0);
        targetDirection.Normalize();
        Vector3 newPosition = transform.position + targetDirection * moveSpeed * Time.deltaTime;
        newPosition = GameManager.Instance.LimitPosition(newPosition);
        if (moveDirection != null)
        {
            moveDirection.Invoke(newPosition);
        }
    }
    public MovementType MoveType() {
        if (joyStick.Direction.x < 0) return MovementType.Backward;
        else if (joyStick.Direction.x > 0) return MovementType.Forward;
        else return default;
    }
    private Vector3 currentScale;
    protected virtual void FaceToEnemy(GameObject targetAttack)
    {
        if (targetAttack == null) return;
        Vector2 direction = DirectionToTarget(targetAttack);
        direction.Normalize();
        float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(Vector3.forward * angel);
    }

    protected virtual void FlipToEnemy(GameObject targetAttack)
    {
        if (targetAttack == null) return;
        transform.localScale = (DirectionToTarget(targetAttack).x < 0)
            ? new Vector3(currentScale.x, -currentScale.y, currentScale.z)
            : new Vector3(currentScale.x, currentScale.y, currentScale.z);
    }
    protected Vector2 DirectionToTarget(GameObject targetAttack)
    {
        return targetAttack.transform.position - this.transform.position;
    }
}
