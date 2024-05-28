using UnityEngine;


public class FaceToPlayer : MonoBehaviour
{
    private SpriteRenderer sprite;
    protected void Awake() {
        sprite = GetComponent<SpriteRenderer>();
    }
    protected void Update() {
        if (CharacterStats.Instance.EnemyHp <= 0) return;
        FaceToTarget(GameObjectManager.Instance.PlayerObject());
        FlipToTarget(GameObjectManager.Instance.PlayerObject());
    }


    protected virtual void FaceToTarget(GameObject targetAttack) {
        if (targetAttack == null) return;
        Vector2 direction = DirectionToTarget();
        direction.Normalize();
        float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(Vector3.forward * angel);
    }

    protected virtual void FlipToTarget(GameObject targetAttack) {
        if (targetAttack == null) return;
        sprite.flipY = (DirectionToTarget().x < 0);

    }
    protected Vector2 DirectionToTarget() {
        Vector2 direction = GameObjectManager.Instance.PlayerObject().transform.position - this.transform.position;
        return direction ;
    }
}
