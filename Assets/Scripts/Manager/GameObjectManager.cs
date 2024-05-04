using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    private GameObject enemyObj;
    private GameObject playerObj;

    public static GameObjectManager Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        enemyObj = GameObject.Find("Enemy");
        playerObj = GameObject.Find("Player");
    }
    public GameObject PlayerObject() {
        return playerObj;
    }
    public GameObject EnemyObject() { 
        return enemyObj;
    }

    public Vector2 Direction() {
        return playerObj.transform.position - enemyObj.transform.position;
    }
    public float DistanceBetweenEnemyPlayer() {
        return Mathf.Abs(Direction().x);
    }

}
