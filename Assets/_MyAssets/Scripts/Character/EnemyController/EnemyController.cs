using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterController
{
    private void Update() {
        Die();
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
            CharacterStats.Instance.TakeDamage(Character.Enemy,
                CharacterStats.Instance.PlayerAtk);
        }
        if (collision.CompareTag("PlayerPunch2")) {
            characterAnimator.SetTakeDamage(TakeDamageType.Type2);
            CharacterStats.Instance.TakeDamage(Character.Enemy,
                CharacterStats.Instance.PlayerAtk);
        }
        if (collision.CompareTag("PlayerPunch3")) {
            characterAnimator.SetTakeDamage(TakeDamageType.Type3);
            CharacterStats.Instance.TakeDamage(Character.Enemy,
                CharacterStats.Instance.PlayerAtk);
        }
    }
    protected override void Die() {
        if (CharacterStats.Instance.EnemyHp <= 0) {
            characterAnimator.SetDie();
        } else characterAnimator.SetIdle();
    }
}
