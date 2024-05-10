using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PunchCombo : MonoBehaviour {
    public List<PunchSO> combo;
    float lastClickTime;
    float lastComboEnd;
    public int comboCount;

    [SerializeField] private CharacterAnimator characterAnimator;
    private Transform player;
    private Rigidbody2D rb;
    public float dashDistance = 1f;
    [SerializeField] GameObject[] punchCollider;
    void Start() {
        rb = GetComponentInParent<Rigidbody2D>();
        player = GameObjectManager.Instance.PlayerObject().transform;
    }
    void Update() {
        if (Mathf.Abs(DirectionToEnemy().x) < GameConstant.attackRange && characterAnimator.currentAnimationState == AnimationState.Attack)
            StopDash();
    }
    public void StartPunch() {
        if (Time.time - lastComboEnd > 0.2f && comboCount <= combo.Count) {
            characterAnimator.SetPunch();
            CancelInvoke("EndCombo");
            if (Time.time - lastClickTime >= 0.3f) {
                DoPunch();
            }
        }
    }
    void DoPunch() {
        characterAnimator.UpdateAnimator(combo[comboCount].animatorOV);
        characterAnimator.SetBool("Punch", true);
        if (comboCount < combo.Count - 1) {
            comboCount++;
            DashDistance(dashDistance);
        } 
        else comboCount = 0;
        lastClickTime = Time.time;
    } 

    public void ExitPunchCombo() {
        if (characterAnimator.currentAnimationState == AnimationState.Attack
            && characterAnimator.currentAttackType == AttackType.Punch) {
            Invoke("EndCombo", 0.3f);
        }
    }
    void EndCombo() {
        characterAnimator.SetBool("Punch", false);
        characterAnimator.SetIdle();
        comboCount = 0;
        lastComboEnd = Time.time;
        StopDash();
    }

    public void DashDistance(float distance) {
        Vector2 direction = DirectionToEnemy();
        direction.Normalize();
        rb.velocity = Vector2.zero;
        rb.AddForce(direction * distance, ForceMode2D.Impulse);
    }
    void StopDash() {
        rb.velocity = Vector2.zero;
    }
    Vector2 DirectionToEnemy() {
        return GameObjectManager.Instance.EnemyObject().transform.position - player.transform.position;
    }
}
