using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PunchComboAI : MonoBehaviour
{
    public List<PunchSO> combo;
    public int comboCount;

    [SerializeField] private CharacterAnimator characterAnimator;
    private Transform player;
    [SerializeField] GameObject[] punchCollider;
    public UnityEvent endPunchCombo;
    void Start() {
        player = GameObjectManager.Instance.PlayerObject().transform;
        //StartCoroutine(DoPunch());
    }
    void Update() {

    }
    public IEnumerator DoPunch() {
        yield return new WaitForSeconds(0.5f);  // Initial delay before starting the combo

        while (comboCount < combo.Count ) {
            characterAnimator.UpdateAnimator(combo[comboCount].animatorOV);
            characterAnimator.SetPunch();
            characterAnimator.SetBool("Punch", true);

            comboCount++;
            yield return new WaitForSeconds(0.4f);
        }

        EndCombo();
    }

    void EndCombo() {
        characterAnimator.SetBool("Punch", false);
        characterAnimator.SetIdle();
        comboCount = 0;
        endPunchCombo?.Invoke();
    }
    Vector2 DirectionToEnemy() {
        return GameObjectManager.Instance.EnemyObject().transform.position - player.transform.position;
    }
}
