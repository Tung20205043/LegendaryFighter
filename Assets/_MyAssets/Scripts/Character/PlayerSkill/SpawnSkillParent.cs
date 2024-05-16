using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkillParent : MonoBehaviour
{
    public IEnumerator SpawnFromPooling(Vector3 playPosition, Vector3 forward, Vector3 up, Vector2 distanceToSpawn, float timeDelayToSpawn, ObjectPoolingForCharacter.ObjectToSpawn objType) {
        yield return new WaitForSeconds(timeDelayToSpawn);
        ObjectPoolingForCharacter.Instance.SpawnObject(objType, SpawnPosition(playPosition, forward, up, distanceToSpawn), SpawmQuaternion(GameObjectManager.Instance.EnemyObject()));
    }
    public Vector3 SpawnPosition(Vector3 playerPosition, Vector3 forward, Vector3 up, Vector2 distanceToSpawn) {
        if (GameObjectManager.Instance.DirectionToEnemy().x < 0) {
            return playerPosition + forward * distanceToSpawn.x - up * distanceToSpawn.y;
        } 
        else return playerPosition + forward * distanceToSpawn.x + up * distanceToSpawn.y;
    }
    protected Quaternion SpawmQuaternion(GameObject targetAttack) {
        if (targetAttack == null) return new Quaternion();
        Vector2 direction = GameObjectManager.Instance.DirectionToEnemy();
        direction.Normalize();
        float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(Vector3.forward * angel);
    }
}
