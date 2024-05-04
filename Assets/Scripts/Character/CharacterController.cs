using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour {
    [SerializeField] protected CharacterAnimator characterAnimator = null;
    [SerializeField] protected CharacterAttack characterAttack = null;
    private Vector3 currentScale;
    protected virtual void OnEnable() {
        currentScale = transform.localScale;
    }

    protected abstract void Move();
    protected abstract void Attack();
    protected abstract void TakeDamage();
    protected abstract void Die();

    protected virtual void FaceToEnemy(GameObject targetAttack) {
        if (targetAttack == null) return;
        Vector2 direction = DirectionToTarget(targetAttack);
        direction.Normalize();
        float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(Vector3.forward * angel);
    }

    protected virtual void FlipToEnemy(GameObject targetAttack) {
        if (targetAttack == null) return;
        transform.localScale = (DirectionToTarget(targetAttack).x < 0)
            ? new Vector3(currentScale.x, -currentScale.y, currentScale.z)
            : new Vector3(currentScale.x, currentScale.y, currentScale.z);
    }
    protected Vector2 DirectionToTarget(GameObject targetAttack) {
        return targetAttack.transform.position - this.transform.position;
    }
}
