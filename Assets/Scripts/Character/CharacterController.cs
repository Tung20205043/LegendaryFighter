using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour {
    [SerializeField] protected CharacterAnimator characterAnimator = null;
    [SerializeField] protected CharacterAttack characterAttack = null;
    [SerializeField] protected CharacterDash characterDash = null;
    private Vector3 currentScale;
    protected virtual void OnEnable() {
        currentScale = transform.localScale;
    }

    protected abstract void Move(Vector3 position);
    protected abstract void BuffMana(bool buff);
    protected abstract void Attack();
    protected abstract void TakeDamage();
    protected abstract void Die();

}
