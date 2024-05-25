using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingForCoin : ObjectPooling
{
    public static ObjectPoolingForCoin Instance { get; private set; }
    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [SerializeField] GameObject objToSpawn;
    public void SpawnObject(Vector3 spawnPoint, Quaternion spawnRotation) {
        GetObjectFromBool(objToSpawn, spawnPoint, spawnRotation);
    }
}
