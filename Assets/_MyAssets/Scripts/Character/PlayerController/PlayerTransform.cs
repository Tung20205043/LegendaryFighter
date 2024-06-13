using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    [SerializeField] CharacterAnimator characterAnimator;
    [SerializeField] AnimatorOverrideController[] overrideController;
    private void OnEnable() {
        int charChooseValue = (int)GameManager.Instance.PlayerChosen;
        //if (charChooseValue == 0) return;
        characterAnimator.UpdateAnimator(overrideController[charChooseValue]);
        StartCoroutine(UpdateValue(charChooseValue));  
    }
    IEnumerator UpdateValue(int value) { 
        yield return new WaitForSeconds(0.5f);
        SpecialUnityEvent.Instance.doTransform?.Invoke(value);
        CharacterStats.Instance.DoTransform(Character.Player, value);
    }
    public void Transform() {
        characterAnimator.UpdateAnimator(overrideController[CharacterStats.Instance.PlayerLevel + 1]);
        characterAnimator.SetIdle();
        characterAnimator.Play("Idle");
        characterAnimator.SetBool("BuffMana", false);
        SpecialUnityEvent.Instance.doTransform?.Invoke(CharacterStats.Instance.PlayerLevel + 1);
        CharacterStats.Instance.DoTransform(Character.Player, CharacterStats.Instance.PlayerLevel + 1);
    }
}
