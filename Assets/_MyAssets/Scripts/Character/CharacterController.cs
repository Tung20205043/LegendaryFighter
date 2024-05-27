using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class CharacterController : MonoBehaviour {
    [SerializeField] public CharacterAnimator characterAnimator = null;
    [SerializeField] protected CharacterDash characterDash = null;
    protected virtual void OnEnable() {

    }

    protected abstract void Move(Vector3 position);
    protected abstract void BuffMana(bool buff);
    protected abstract void Attack(AttackType type);
    protected abstract void Defend(bool defending);
    protected abstract void Die();

    protected bool CanCastSkill(Character character, AttackType type) {
        float manaRequired;
        manaRequired = GameConstant.manaToCastSkill[(int)type];
        return CheckCurrentMana(character, manaRequired);
    }
    protected bool CanDash(Character character) {
        float manaRequired;
        manaRequired = GameConstant.manaToDash;
        return CheckCurrentMana(character, manaRequired);
    }
    bool CheckCurrentMana(Character character, float manaRequired) {
        CharacterStats stats = CharacterStats.Instance;
        if (character == Character.Player) {
            if (stats.PlayerMana < manaRequired) {
                Debug.Log("Player is out of mana.");
                return false;
            } else {
                //Debug.Log("Player is casting skill.");
                return true;
            }
        } else if (character == Character.Enemy) {
            if (stats.EnemyMana < manaRequired) {
                Debug.Log("Enemy is out of mana.");
                return false;
            } else {
                stats.ChangeCurrentMana(character, -manaRequired);
                return true;
            }
        }
        return false;
    }
    protected void CannotExitScreen() {
        this.transform.position = GamePositionManager.Instance.LimitPosition(transform.position);
    }

}
