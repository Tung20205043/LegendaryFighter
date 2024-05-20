using System.Collections;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour {
    private Animator animator;
    public AnimationState currentAnimationState;
    protected MovementType currentMovementType;
    public bool isAttack;
    public AttackType currentAttackType;
    protected string currentTrigger = "";
    private void Update() {
        isAttack = CheckForCombo.isSpecialAttack;
    }
    public Animator Animator {
        get {
            if (animator == null)
                animator = GetComponent<Animator>();
            return animator;
        }
    }

    //--------------------------------------------------
    public void SetIdle() {
        SetTrigger("Idle");
        currentAnimationState = AnimationState.Idle;
        currentAttackType = AttackType.Defaut;
    }
    public void SetMovement(MovementType type) {

        SetFloat("MovementType", (int)type);
        SetBool("Movement", true);

        currentAnimationState = AnimationState.Movement;
        currentMovementType = type;
    }
    public void StopMovement() {
        SetBool("Movement", false);
        //SetIdle();
    }
    public void SetBuffMana(bool onBuff) {
        SetBool("BuffMana", onBuff);
        if (onBuff) {
            currentAnimationState = AnimationState.BuffMana;
        } 
        if (!onBuff){
            SetIdle();
        }
    }
    public void SetDash() {
        SetTrigger("Dash");
        currentAnimationState = AnimationState.Dash;
    }
    public void SetDefend(bool isDefending) {
        SetBool("Defend", isDefending);
        currentAnimationState = isDefending ? AnimationState.Defend : AnimationState.Idle;
    }
    public void SetPunch() {
        currentAnimationState = AnimationState.Attack;
        currentAttackType = AttackType.Punch;
    }

    public void SetSkill(AttackType type, bool isSpecialAttack) {
        if (isSpecialAttack) {
            SetTrigger("SpecialSkill");
        }
        SetBool("Skill", true);
        SetFloat("SkillType", (int)type);
        currentAnimationState = AnimationState.Attack;
        currentAttackType = type;
        StartCoroutine(StopSkill(GameConstant.timeUseSkill[(int)type]));
    }
    IEnumerator StopSkill(float time) {
        yield return new WaitForSeconds(time);
        SetBool("Skill", false);
        SetIdle();
    }
    public void SetTakeDamage(TakeDamageType type) {
        SetBool("TakeDamage", true);
        SetFloat("TakeDamageType", (int)type);
        currentAnimationState = AnimationState.TakeDamage;
        StartCoroutine(StopTakeDmgAnim(GameConstant.takeDmgTime[(int)type]));
    }
    IEnumerator StopTakeDmgAnim(float time) {
        yield return new WaitForSeconds(time);
        SetBool("TakeDamage", false);
        SetIdle();
    }
    public void SetTransform() {
        StartCoroutine(TransformToNextState());
        SetBuffMana(true);  
    }
    IEnumerator TransformToNextState() {
        yield return new WaitForSeconds(2f);
        Debug.Log("trans");
        SetTrigger("Transform");
    }
    public void SetDie() {
        SetTrigger("Die");
        currentAnimationState = AnimationState.Die;
    }
    //--------------------------------------------------
    public void Play(string nameAnim) {
        Debug.Log(nameAnim);
        animator.Play(nameAnim);
    }
    public void SetTrigger(string parameters) {
        Animator.SetTrigger(parameters);
        currentTrigger = parameters;
    }
    public void SetBool(string parameters, bool value) { 
        Animator.SetBool(parameters, value);
    }
    public void SetFloat(string parameters, float value) { 
        Animator.SetFloat(parameters, value);
    }
    public void UpdateAnimator(RuntimeAnimatorController value) {
        Animator.runtimeAnimatorController = value;
    }
}
