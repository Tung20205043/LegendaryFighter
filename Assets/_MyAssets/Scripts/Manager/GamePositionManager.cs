using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GamePositionManager : MonoBehaviourSingleton<GamePositionManager>
{
    public float groundCheck;
    public Transform[] limitedPoint;
    public float LimitedLeft() { return limitedPoint[0].position.x; }
    public float LimitedRight() { return limitedPoint[1].position.x; }
    public float LimitedTop() { return limitedPoint[0].position.y; }
    public float GroundPosition() { return limitedPoint[1].position.y; }
    public Vector3 LimitPosition(Vector3 position) {
        float limitedX = Mathf.Clamp(position.x, LimitedLeft(), LimitedRight());
        float limitedY = Mathf.Clamp(position.y, GroundPosition(), LimitedTop());
        return new Vector3(limitedX, limitedY, position.z);
    }
    public bool IsOnLimitPoint(Character character) {
        GameObjectManager instance = GameObjectManager.Instance;
        GameObject objToCheck = character == Character.Player ? instance.PlayerObject() : instance.EnemyObject();
        Vector2 posToCheck = objToCheck.transform.position;
        return posToCheck.x - LimitedLeft() < groundCheck || posToCheck.x - LimitedRight() > groundCheck ||
            posToCheck.y - LimitedTop() > groundCheck || posToCheck.y - GroundPosition() < groundCheck;
    }
}
