using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour {
    [SerializeField] public CharacterAnimator characterAnimator = null;
    [SerializeField] protected CharacterDash characterDash = null;
    [SerializeField] protected CharacterTakeDamage characterTakeDamage = null;
    protected virtual void OnEnable() {

    }

    protected abstract void Move(Vector3 position);
    protected abstract void BuffMana(bool buff);
    protected abstract void Attack(AttackType type);
    protected abstract void Defend(bool defending);
    protected abstract void Die();

    protected bool CanCastSkill(Character character, AttackType type, bool isDash) {
        float manaRequired;
        if (!isDash) {
            manaRequired = GameConstant.manaToCastSkill[(int)type];
        } else
            manaRequired = GameConstant.manaToDash;
        CharacterStats stats = CharacterStats.Instance;

        if (character == Character.Player) {
            if (stats.PlayerMana < manaRequired) {
                Debug.Log("Player is out of mana.");
                return false;
            } else {
                stats.PayMana(character, manaRequired);
                return true;
            }
        } else if (character == Character.Enemy) {
            if (stats.EnemyMana < manaRequired) {
                Debug.Log("Enemy is out of mana.");
                return false;
            } else {
                stats.PayMana(character, manaRequired);
                return true;
            }
        }
        return false;
    }
    protected void CannotExitScreen() {
        this.transform.position = GameManager.Instance.LimitPosition(transform.position);
    }

}
