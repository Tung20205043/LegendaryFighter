using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;
    protected AnimationState currentAnimationState;

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
    }
    public void SetMovement(MovementType type) {
        SetFloat("MovementType", (int)type);
        SetTrigger("Movement");
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
