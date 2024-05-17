using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AIHeavyPunch : MonoBehaviour
{
    public float timeToTele = 0.2f;
    //public GameObject kickCollider;
    private GameObject enemyObj;
    [SerializeField] PunchComboAI punchComboAI;
    [SerializeField] CharacterAnimator characterAnimator;
    public UnityEvent endHeavyPunch;
    private void Start() {
        punchComboAI.endPunchCombo.AddListener(DoTeleport);
    }
    public void DoTeleport() {
        characterAnimator.SetSkill(AttackType.HeavyPunch);
        enemyObj = GameObjectManager.Instance.EnemyObject();
        //kickCollider.SetActive(true);
        StartCoroutine(TeleportToPosition());
    }
    IEnumerator TeleportToPosition() {
        yield return new WaitForSeconds(timeToTele);
        enemyObj.transform.position = TelePosition();
        yield return new WaitForSeconds(0.1f);
        endHeavyPunch?.Invoke();
        //kickCollider.SetActive(false);
    }
    public Vector3 TelePosition() {
        return GetPlayerTelePosition.Instance.BackTransform;
    }
}
