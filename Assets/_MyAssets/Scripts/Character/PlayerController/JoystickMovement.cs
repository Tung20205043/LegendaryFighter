using UnityEngine;
using UnityEngine.Events;

public class JoystickMovement : MonoBehaviour
{
    GameObject joyObj;
    protected Joystick joyStick = null;
    public UnityEvent<Vector3> moveDirection = null;
    private SpriteRenderer sprite;
    protected void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        joyObj = GameObject.Find("Variable Joystick");
        joyStick = joyObj.GetComponent<Joystick>();
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
        float xDirection = joyStick.Direction.x;
        float yDirection = joyStick.Direction.y;
        Vector3 targetDirection = DirectionToTarget();

        if (Mathf.Abs(xDirection) <= 0.4f && !GameManager.Instance.IsOnLimitPoint(Character.Player)) {
            if (yDirection * targetDirection.y >= 0)
                return MovementType.Down;
            else
                return MovementType.Up;       
        } 
        else {
            if (xDirection * targetDirection.x < 0)
                return MovementType.Backward;
            else
                return MovementType.Forward;
        }
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
