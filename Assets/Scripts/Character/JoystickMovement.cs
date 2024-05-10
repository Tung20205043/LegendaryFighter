using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JoystickMovement : MonoBehaviour
{

    [SerializeField] protected Joystick joyStick = null;
    public UnityEvent<Vector3> moveDirection = null;
    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    protected void Update()
    {
        FaceToEnemy(GameObjectManager.Instance.EnemyObject());
        FlipToEnemy(GameObjectManager.Instance.EnemyObject());
        UpdateNewPosition();
    }
    public void UpdateNewPosition()
    {
        Vector3 targetDirection = new Vector3(joyStick.Direction.x, joyStick.Direction.y, 0);
        targetDirection.Normalize();
        moveDirection?.Invoke(targetDirection);
    }
    public MovementType MoveType() {
        if (joyStick.Direction.x * DirectionToTarget().x < 0) return MovementType.Backward;
        else if (joyStick.Direction.x * DirectionToTarget().x > 0) return MovementType.Forward;
        else return default;
    }

    protected virtual void FaceToEnemy(GameObject targetAttack)
    {
        if (targetAttack == null) return;
        Vector2 direction = DirectionToTarget();
        direction.Normalize();
        float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(Vector3.forward * angel);
    }

    protected virtual void FlipToEnemy(GameObject targetAttack)
    {
        if (targetAttack == null) return;
        sprite.flipY = (DirectionToTarget().x < 0);

    }
    protected Vector2 DirectionToTarget()
    {
        return GameObjectManager.Instance.EnemyObject().transform.position - this.transform.position;
    }
}
