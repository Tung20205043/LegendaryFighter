using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterController
{
    private void Update() {
        Die();
        CannotExitScreen();
    }
    protected override void Move(Vector3 position) {
        throw new System.NotImplementedException();
    }
    protected override void Attack(AttackType type) {
        throw new System.NotImplementedException();
    }
    protected override void BuffMana(bool buff) {
        throw new System.NotImplementedException();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("PlayerPunch1")) {
            characterAnimator.SetTakeDamage(TakeDamageType.Type1);
            characterTakeDamage.DoTakeDamage(TakeDamageType.Type1);
        }
        if (collision.CompareTag("PlayerPunch2")) {
            characterAnimator.SetTakeDamage(TakeDamageType.Type2);
            characterTakeDamage.DoTakeDamage(TakeDamageType.Type2);
        }
        if (collision.CompareTag("PlayerPunch3")) {
            characterAnimator.SetTakeDamage(TakeDamageType.Type3);
            characterTakeDamage.DoTakeDamage(TakeDamageType.Type3);
        }
    }
    protected override void Die() {
        if (CharacterStats.Instance.EnemyHp <= 0) {
            characterAnimator.SetDie();
        } else characterAnimator.SetIdle();
    }
}
