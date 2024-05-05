using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;
    public AnimationState currentAnimationState;
    protected MovementType currentMovementType;
    protected string currentTrigger = "";
    public Animator Animator { 
        get { 
            if (animator == null) 
                animator = GetComponent<Animator>();
            return animator; 
        } 
    }
    public void SetIdle() {
        SetTrigger("Idle");
        currentAnimationState = AnimationState.Idle;
    }
    public void SetMovement(MovementType type) {

        SetFloat("MovementType", (int)type);
        SetTrigger("Movement");

        currentAnimationState = AnimationState.Movement;
        currentMovementType = type;
    }
    public void SetBuffMana(bool onBuff) {

        SetBool("BuffMana", onBuff);
        currentAnimationState = onBuff ? AnimationState.BuffMana : AnimationState.Idle;
    }
    public void SetDash() {
        SetTrigger("Dash");
        currentAnimationState = AnimationState.Dash;
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
}
