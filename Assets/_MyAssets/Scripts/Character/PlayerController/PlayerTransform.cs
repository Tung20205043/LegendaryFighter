using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    [SerializeField] CharacterAnimator characterAnimator;
    [SerializeField] AnimatorOverrideController overrideController;
    public void Transform() {
        characterAnimator.UpdateAnimator(overrideController);
        characterAnimator.SetIdle();
        characterAnimator.Play("Idle");
        characterAnimator.SetBool("BuffMana", false);
        SpecialUnityEvent.Instance.doTransform?.Invoke();
    }
}
