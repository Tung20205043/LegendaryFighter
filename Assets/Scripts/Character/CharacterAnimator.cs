using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;
    public AnimationState currentAnimationState;
    protected MovementType currentMovementType;
    public AttackType currentAttackType;
    protected string currentTrigger = "";
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
        SetIdle();  
    }
    public void SetBuffMana(bool onBuff) {
        SetBool("BuffMana", onBuff);
        currentAnimationState = onBuff ? AnimationState.BuffMana : AnimationState.Idle;
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
    
    public void SetSkill(AttackType type) {
        SetBool("Skill", true);
        SetFloat("SkillType",(int)type);
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
        StartCoroutine(StopTakeDmgAnim(GameConstant.takeDmgTime));
    }
    IEnumerator StopTakeDmgAnim(float time) { 
        yield return new WaitForSeconds(time);
        SetBool("TakeDamage", false);
        SetIdle();
    }
    
    //--------------------------------------------------
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
