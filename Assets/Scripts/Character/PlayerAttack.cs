using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Transform enemyObj;
    private void Start() {
        enemyObj = GameObjectManager.Instance.EnemyObject().transform;
    }
    public void SpawnSkill(AttackType type, Vector3 playPosition) {
        ObjectPooling.Instance.SpawnObject(2, SpawnPosition(playPosition),SpawmQuaternion(enemyObj.gameObject), 1);
    }

    public Vector3 SpawnPosition(Vector3 playerPosition) { 
        return new Vector3 (playerPosition.x, playerPosition.y, playerPosition.z);  
    }

    protected Quaternion SpawmQuaternion(GameObject targetAttack) {
        if (targetAttack == null) return new Quaternion();
        Vector2 direction = DirectionToTarget();
        direction.Normalize();
        float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(Vector3.forward * angel);
    }
    protected Vector2 DirectionToTarget() {
        return enemyObj.position - this.transform.position;
    }
}
