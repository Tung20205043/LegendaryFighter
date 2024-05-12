using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUltSkill : MonoBehaviour
{
    [SerializeField] GameObject switchCameraController;
    public float timeZoomCamera = 1.5f;
    public Vector2 distanceToSpawn = new Vector2(0f, 0.2f);
    public float timeDelayToSpawn = 0.2f;
    public static bool ultSkillCanMove;
    public void DoSpawnUltSkill(Vector3 playerPos) {
        ultSkillCanMove = false;
        StartCoroutine(SpawnSkill());
        StartCoroutine(SpawnFromPooling(playerPos));
    }
    IEnumerator SpawnSkill() { 
        switchCameraController.SetActive(true);
        yield return new WaitForSeconds(timeZoomCamera);
        switchCameraController.SetActive(false);
        ultSkillCanMove = true;
    }

    IEnumerator SpawnFromPooling(Vector3 playPosition) {
        yield return new WaitForSeconds(timeDelayToSpawn);
        ObjectPooling.Instance.SpawnObject(3, SpawnPosition(playPosition), SpawmQuaternion(GameObjectManager.Instance.EnemyObject()), 1);
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
