using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterController
{
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
        }
        if (collision.CompareTag("PlayerPunch2")) {
            characterAnimator.SetTakeDamage(TakeDamageType.Type2);
        }
        if (collision.CompareTag("PlayerPunch3")) {
            characterAnimator.SetTakeDamage(TakeDamageType.Type3);
        }
    }
    protected override void Die() {
        throw new System.NotImplementedException();
    }
}
