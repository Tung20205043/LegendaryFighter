using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkill1 : MonoBehaviour
{
    public Vector2 distanceToSpawn = new Vector2(0.2f, 0.05f);
    public float timeDelayToSpawn = 0.2f;
    public void DoSpawnSkill1(Vector3 playerPosition) {
        StartCoroutine(SpawnFromPooling(playerPosition));
    }
    IEnumerator SpawnFromPooling(Vector3 playPosition) {
        yield return new WaitForSeconds(timeDelayToSpawn);
        ObjectPooling.Instance.SpawnObject(2, SpawnPosition(playPosition), SpawmQuaternion(GameObjectManager.Instance.EnemyObject()), 1);
    }
    public Vector3 SpawnPosition(Vector3 playerPosition) {
        return new Vector3(playerPosition.x + distanceToSpawn.x, playerPosition.y + distanceToSpawn.y, playerPosition.z);
    }

    protected Quaternion SpawmQuaternion(GameObject targetAttack) {
        if (targetAttack == null) return new Quaternion();
        Vector2 direction = GameObjectManager.Instance.DirectionToEnemy();
        direction.Normalize();
        float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(Vector3.forward * angel);
    }
}
