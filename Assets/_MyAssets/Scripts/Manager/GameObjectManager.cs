using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviourSingleton<GameObjectManager>
{
    private GameObject enemyObj;
    private GameObject playerObj;

    private void Awake() {
        enemyObj = GameObject.FindWithTag("Enemy");
        playerObj = GameObject.FindWithTag("Player");
    }
    public GameObject PlayerObject() {
        return playerObj;
    }
    public GameObject EnemyObject() { 
        return enemyObj;
    }

    public Vector2 DirectionToEnemy() {
        return enemyObj.transform.position - playerObj.transform.position;
    }
    public float DistanceBetweenEnemyPlayer() {
        return Mathf.Abs(DirectionToEnemy().x);
    }

}
