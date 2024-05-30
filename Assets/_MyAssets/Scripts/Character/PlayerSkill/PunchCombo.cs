using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PunchCombo : MonoBehaviour {
    [System.Serializable]
    public class PunchSOArrayWrapper {
        public PunchSO[] comboPunchArray;
    }
    [SerializeField] List<PunchSOArrayWrapper> arrayList;
    //public PunchSO[] combo;
    float lastClickTime;
    float lastComboEnd;
    public int comboCount;

    [SerializeField] private CharacterAnimator characterAnimator;
    private Transform player;
    private Rigidbody2D rb;
    public float dashDistance = 1f;
    [SerializeField] RaycastCheck raycastCheck;
    void Start() {
        rb = GetComponentInParent<Rigidbody2D>();
        player = GameObjectManager.Instance.PlayerObject().transform;
        SpecialUnityEvent.Instance.doTransform.AddListener(UpdatePunchSO);
    }
    void Update() {
        if (IsInAttackRange())
            StopDash();
    }
    bool IsInAttackRange() {
        return Mathf.Abs(DirectionToEnemy().x) < GameConstant.attackRange 
            && characterAnimator.currentAttackType == AttackType.Punch;
    }
    public void StartPunch() {
        if (Time.time - lastComboEnd > 0.2f && comboCount <= arrayList[0].comboPunchArray.Length) {
            characterAnimator.SetPunch();
            CancelInvoke("EndCombo");
            if (Time.time - lastClickTime >= 0.3f) {
                DoPunch();
            }
        }
    }
    void DoPunch() {
        characterAnimator.UpdateAnimator(arrayList[0].comboPunchArray[comboCount].animatorOV);
        raycastCheck.CheckObjByRaycast(comboCount);
        characterAnimator.SetBool("Punch", true);
        if (comboCount < arrayList[0].comboPunchArray.Length - 1) {
            comboCount++;
            DashDistance(dashDistance);
        } 
        else comboCount = 0;
        lastClickTime = Time.time;
    } 

    public void ExitPunchCombo() {
        if (characterAnimator.currentAnimationState == AnimationState.Punch
            && characterAnimator.currentAttackType == AttackType.Punch) {
            Invoke("EndCombo", /*(comboCount == 0) ? 0.1f :*/ 0.3f);
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
    void UpdatePunchSO(int levelTarget) {
        GameUltis.ReplaceArrayElements(arrayList[0].comboPunchArray, arrayList[levelTarget].comboPunchArray);      
    }
}
