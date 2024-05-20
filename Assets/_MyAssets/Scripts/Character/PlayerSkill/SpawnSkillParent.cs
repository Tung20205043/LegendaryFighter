using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkillParent : MonoBehaviour
{

    public IEnumerator SpawnFromPooling(AttackType type, float timeDelayToSpawn, ObjectPoolingForCharacter.ObjectToSpawn objType) {
        yield return new WaitForSeconds(timeDelayToSpawn);
        ObjectPoolingForCharacter.Instance.SpawnObject(objType,SpawnPosition(type), SpawmQuaternion(GameObjectManager.Instance.EnemyObject()));
    }

    Vector3 spawnPos;
    public Vector3 SpawnPosition(AttackType attackType) {
        if (attackType == AttackType.Skill) 
            spawnPos = GetPlayerPoint.Instance.SkillPos;
        if (attackType == AttackType.UltimateSkill)
            spawnPos = GetPlayerPoint.Instance.UltSkillPos;
        return spawnPos;

    }
    protected Quaternion SpawmQuaternion(GameObject targetAttack) {
        if (targetAttack == null) return new Quaternion();
        Vector2 direction = GameObjectManager.Instance.DirectionToEnemy();
        direction.Normalize();
        float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(Vector3.forward * angel);
    }
}
