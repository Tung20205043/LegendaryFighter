using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public float timeToTele = 0.2f;
    private GameObject playerObj;
    public void DoTeleport() {
        playerObj = GameObjectManager.Instance.PlayerObject();
        StartCoroutine(TeleportToPosition());
    }
    IEnumerator TeleportToPosition() {
        yield return new WaitForSeconds(timeToTele);
        playerObj.transform.position = TelePosition();
    }
    public Vector3 TelePosition()
    {
        return GetEnemyTelePosition.Instance.BackTransform;
    }
}
    