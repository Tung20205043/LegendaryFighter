using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeavyPunch : MonoBehaviour {
    public Vector2 distanceToTele = new Vector2(2f, 0f);
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
        //if (GameObjectManager.Instance.DirectionToEnemy().x < 0) {
        //    return enemyPosition + forward * distanceToTele.x - up * distanceToTele.y;
        /*} else*/
        return GetTelePosition.Instance.BackTransform;
    }
}
