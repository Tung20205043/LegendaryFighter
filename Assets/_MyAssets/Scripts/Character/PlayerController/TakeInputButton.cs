using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TakeInputButton : MonoBehaviour
{
    [SerializeField] HoldButton buffManaButton;
    [SerializeField] Button levelUpButton;
    [SerializeField] Button[] attackButton;
    [SerializeField] Button dashButton;
    [SerializeField] HoldButton defendButton;

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
        attackButton[3].onClick.AddListener(() => Attacking(AttackType.HeavyPunch));

        buffManaButton.holdButton.AddListener(BuffingMana);
        defendButton.holdButton.AddListener(Defending);
    }
    //---------------------------------
    public void BuffingMana(bool state) {
        isBuffingMana?.Invoke(state);
        firstComboInputEvent?.Invoke("Q");
    }
    public void StopBuffMana() { 
        isBuffingMana?.Invoke(false);
    }
    //---------------------------------
    public void Defending(bool state) {
        isDefending?.Invoke(state);
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
        if (!CheckForCombo.isSpecialAttack) {
            isDashing?.Invoke();
        } else
            secondComboInputEvent?.Invoke("D");
    }
}
