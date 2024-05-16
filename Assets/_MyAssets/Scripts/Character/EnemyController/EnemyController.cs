using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterController
{
    private TakeInputButton inputButton;
    [SerializeField] GameObject inputButtonObj;
    [SerializeField] CharacterController player;
    private void Awake() {
        inputButtonObj = GameObject.Find("ButtonInput");
        inputButton = inputButtonObj.GetComponent<TakeInputButton>();
    }
    private void Start() {
        inputButton.attacking.AddListener(CallDefend);
        inputButton.isBuffingMana.AddListener(BuffMana);
        inputButton.isDefending.AddListener(BuffMana);
    }
    private void Update() {
        if (CantBuffMana()) {
            BuffMana(false);
        }
        Die();
        CannotExitScreen();
        if (player.characterAnimator.currentAnimationState != AnimationState.Defend) {
            //Debug.Log("Attack Player");
        }
        //Debug.Log(CantBuffMana());
    }
    bool CantBuffMana() { 
        return (CharacterStats.Instance.IsMaxMana(Character.Enemy)) ;
    }
    protected override void Move(Vector3 position) {
        throw new System.NotImplementedException();
    }
    protected override void Attack(AttackType type) {
        throw new System.NotImplementedException();
    }
    protected override void BuffMana(bool buff) {
        if (CantBuffMana() && buff) return;
        CharacterStats.Instance.ChangeBuffManaState(buff, Character.Enemy);
        characterAnimator.SetBuffMana(buff);
    }
    void CallDefend(AttackType type) {
        //Defend(true);
    }
    protected override void Defend(bool defending) {
        characterAnimator.SetDefend(defending);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (characterAnimator.currentAnimationState == AnimationState.Defend) return;
        if (collision.CompareTag("PlayerPunch1")) {
            Debug.Log("take damage 1");
            characterAnimator.SetTakeDamage(TakeDamageType.Type1);
            characterTakeDamage.DoTakeDamage(TakeDamageType.Type1);
        }
        if (collision.CompareTag("PlayerPunch2")) {
            Debug.Log("take damage 2");
            characterAnimator.SetTakeDamage(TakeDamageType.Type2);
            characterTakeDamage.DoTakeDamage(TakeDamageType.Type2);
        }
        if (collision.CompareTag("PlayerPunch3")) {
            Debug.Log("take damage 3");
            characterAnimator.SetTakeDamage(TakeDamageType.Type3);
            characterTakeDamage.DoTakeDamage(TakeDamageType.Type3);
        }
    }
    protected override void Die() {
        if (CharacterStats.Instance.EnemyHp <= 0) {
            characterAnimator.SetDie();
        } 
    }
}
