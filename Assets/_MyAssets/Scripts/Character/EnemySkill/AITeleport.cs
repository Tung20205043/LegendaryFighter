using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AITeleport : MonoBehaviour
{
    public float timeToTele = 0.2f;
    private GameObject enemyObj;
    [SerializeField] private AIHeavyPunch AIHeavyPunch;
    [SerializeField] private CharacterAnimator characterAnimator;
    public UnityEvent endTeleport;
    private void Start() {
        AIHeavyPunch.endHeavyPunch.AddListener(DoTeleport);
    }
    public void DoTeleport() {
        characterAnimator.SetSkill(AttackType.Teleport);
        enemyObj = GameObjectManager.Instance.EnemyObject();
        StartCoroutine(TeleportToPosition());
    }
    IEnumerator TeleportToPosition() {
        yield return new WaitForSeconds(timeToTele);
        enemyObj.transform.position = TelePosition();
        endTeleport?.Invoke();
    }
    public Vector3 TelePosition() {
        return GetPlayerTelePosition.Instance.BackTransform;
    }
}
