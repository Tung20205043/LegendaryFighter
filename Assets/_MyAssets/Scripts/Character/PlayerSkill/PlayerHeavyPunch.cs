using System.Collections;
using UnityEngine;

public class PlayerHeavyPunch : MonoBehaviour {
    public float timeToTele = 0.2f;
    public GameObject kickCollider;
    private GameObject playerObj;
    public void DoTeleport() {
        playerObj = GameObjectManager.Instance.PlayerObject();
        kickCollider.SetActive(true);
        StartCoroutine(TeleportToPosition());
    }
    IEnumerator TeleportToPosition() {
        yield return new WaitForSeconds(timeToTele);
        playerObj.transform.position = TelePosition();
        yield return new WaitForSeconds(timeToTele);
        kickCollider.SetActive(false);
    }
    public Vector3 TelePosition() {
        return GetEnemyTelePosition.Instance.BackTransform;
    }
}
