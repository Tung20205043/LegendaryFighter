using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTransform : MonoBehaviour
{
    [SerializeField] CharacterAnimator characterAnimator;
    [SerializeField] AnimatorOverrideController[] overrideController;
    private void OnEnable() {
        int charChooseValue = (int)GameManager.Instance.EnemyChosen;
        characterAnimator.UpdateAnimator(overrideController[charChooseValue]);
        StartCoroutine(UpdateValue(charChooseValue));
    }
    IEnumerator UpdateValue(int value) {
        yield return new WaitForSeconds(0.5f);
        SpecialUnityEvent.Instance.enemyDoTransform?.Invoke(value);
        CharacterStats.Instance.DoTransform(Character.Enemy, value);
    }
    public void Transform() {
        characterAnimator.UpdateAnimator(overrideController[CharacterStats.Instance.PlayerLevel + 1]);
        characterAnimator.SetIdle();
        characterAnimator.Play("Idle");
        characterAnimator.SetBool("BuffMana", false);
        SpecialUnityEvent.Instance.enemyDoTransform?.Invoke(CharacterStats.Instance.EnemyLevel + 1);
        CharacterStats.Instance.DoTransform(Character.Player, CharacterStats.Instance.EnemyLevel + 1);
    }
}
