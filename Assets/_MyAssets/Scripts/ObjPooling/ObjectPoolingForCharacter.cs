using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPoolingForCharacter : ObjectPooling{
    public static ObjectPoolingForCharacter Instance { get; private set; }

    public enum ObjectToSpawn {GhostEffect, GhostEffect1, GokuSkill, GokuUltSkill, Kameha, TakeDamageGhost, TakeDamageGhost1 }
    [System.Serializable]
    public struct SpawnableObject {
        public ObjectToSpawn key;
        public GameObject value;
    }
    [SerializeField] private SpawnableObject[] spawnableObjectsArray;
    private Dictionary<ObjectToSpawn, GameObject> spawnableObjectsDict;
    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Initialize the dictionary
        spawnableObjectsDict = new Dictionary<ObjectToSpawn, GameObject>();
        foreach (var item in spawnableObjectsArray) {
            spawnableObjectsDict.Add(item.key, item.value);
        }
    }
    public GameObject GetObjectByKey(ObjectToSpawn key) {
        if (spawnableObjectsDict.TryGetValue(key, out var obj)) {
            return obj;
        } else {
            Debug.LogWarning("Key not found: " + key);
            return null;
        }
    }
    public void SpawnObject(ObjectToSpawn objType, Vector3 spawnPoint, Quaternion spawnRotation) {
        GetObjectFromBool(GetObjectByKey(objType), spawnPoint, spawnRotation);
    }


}
