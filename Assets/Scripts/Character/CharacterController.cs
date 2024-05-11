using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour {
    [SerializeField] protected CharacterAnimator characterAnimator = null;
    [SerializeField] protected CharacterDash characterDash = null;
    private Vector3 currentScale;
    protected virtual void OnEnable() {
        currentScale = transform.localScale;
    }

    protected abstract void Move(Vector3 position);
    protected abstract void BuffMana(bool buff);
    protected abstract void Attack(AttackType type);
    protected abstract void Die();

    protected bool CanCastSkill(Character character, GameConstant.SkillUseMana skill) {
        float manaRequired = GameConstant.manaToCastSkill[(int)skill];
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

}
