using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraRotation : MonoBehaviour
{
    private void OnEnable() {
        Vector2 direction = DirectionToTarget();
        if (direction.x < 0) {
            transform.localRotation = Quaternion.Euler(180, 0, 0);
        } else if (direction.x > 0) {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    protected Vector2 DirectionToTarget() {
        return GameObjectManager.Instance.EnemyObject().transform.position - GameObjectManager.Instance.PlayerObject().transform.position;
    }
}
