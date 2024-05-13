using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TakeInputButton : MonoBehaviour
{
    [SerializeField] Button buffManaButton;
    [SerializeField] Button levelUpButton;
    [SerializeField] Button[] attackButton;
    [SerializeField] Button dashButton;
    [SerializeField] Button defendButton;

    public UnityEvent<bool> isBuffingMana;
    public UnityEvent<bool> isDefending;
    public UnityEvent isDashing;
    public UnityEvent<AttackType> attacking;
    public UnityEvent<string> firstComboInputEvent;
    public UnityEvent<string> secondComboInputEvent;
    private void Awake() {
        dashButton.onClick.AddListener(Dashing);
        attackButton[0].onClick.AddListener(() => Attacking(AttackType.Punch));
        attackButton[1].onClick.AddListener(() => Attacking(AttackType.Skill));
        attackButton[2].onClick.AddListener(() => Attacking(AttackType.UltimateSkill));
    }
    //---------------------------------
    public void BuffingMana() {
        isBuffingMana?.Invoke(true);
        firstComboInputEvent?.Invoke("Q");
    }
    public void StopBuffMana() { 
        isBuffingMana?.Invoke(false);
    }
    //---------------------------------
    public void Defending() {
        isDefending?.Invoke(true);
    }
    public void StopDefending() { 
        isDefending?.Invoke(false);
    }
    //---------------------------------
    public void Attacking(AttackType type) {
        if (!CheckForCombo.isSpecialAttack) {
            attacking?.Invoke(type);
        } else
            secondComboInputEvent?.Invoke(GameConstant.AttackCode[(int)type]);
    }
    public void Dashing() {
        isDashing?.Invoke();
        secondComboInputEvent?.Invoke("D");
    }
}
