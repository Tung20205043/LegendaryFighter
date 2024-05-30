using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraRotation : MonoBehaviour
{
    [SerializeField] Character character;
    private void Update() {
        Vector2 direction = DirectionToTarget();
        if (direction.x < 0) {
            transform.localRotation = Quaternion.Euler(180, 0, 0);
        } else if (direction.x > 0) {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    protected Vector2 DirectionToTarget() {
        if (character == Character.Player) {
            return GameObjectManager.Instance.EnemyObject().transform.position - GameObjectManager.Instance.PlayerObject().transform.position;
        }
        else
            return -GameObjectManager.Instance.EnemyObject().transform.position + GameObjectManager.Instance.PlayerObject().transform.position;
    }
}
