using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeavyPunch : MonoBehaviour {
    public Vector2 distanceToTele = new Vector2(2f, 0f);
    public float timeToTele = 0.2f;
    public GameObject kickCollider;
    private GameObject playerObj;
    private GameObject enemyObj;
    public void DoTeleport() {
        playerObj = GameObjectManager.Instance.PlayerObject();
        enemyObj = GameObjectManager.Instance.EnemyObject();
        kickCollider.SetActive(true);
        StartCoroutine(TeleportToPosition());
    }
    IEnumerator TeleportToPosition() {
        yield return new WaitForSeconds(timeToTele);
        playerObj.transform.position = TelePosition(enemyObj.transform.position, enemyObj.transform.forward, enemyObj.transform.up);
        yield return new WaitForSeconds(timeToTele);
        kickCollider.SetActive(false);
    }
    public Vector3 TelePosition(Vector3 enemyPosition, Vector3 forward, Vector3 up) {
        //if (GameObjectManager.Instance.DirectionToEnemy().x < 0) {
        //    return enemyPosition + forward * distanceToTele.x - up * distanceToTele.y;
        /*} else*/
        return enemyPosition + forward * distanceToTele.x + up * distanceToTele.y;
    }
}
