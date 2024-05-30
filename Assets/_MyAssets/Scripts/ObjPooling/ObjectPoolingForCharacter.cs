using System.Collections.Generic;
using UnityEngine;


public class ObjectPoolingForCharacter : ObjectPooling{
    public static ObjectPoolingForCharacter Instance { get; private set; }

    public enum ObjectToSpawn {GhostEffect, GhostEffect1, PunchGhost, PunchGhost1, GokuSkill, GokuUltSkill, Kameha, TakeDamageGhost, TakeDamageGhost1 }
    [System.Serializable]
    public struct SpawnableObject {
        public ObjectToSpawn key;
        public GameObject value;
    }
    [System.Serializable]
    public class SpawnableObjectArrayWrapper {
        public SpawnableObject[] spawnObjectsArray;
    }
    [SerializeField] private List<SpawnableObjectArrayWrapper> spawnablesList;

    private Dictionary<ObjectToSpawn, GameObject> spawnableObjectsDict;
    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        UpdateDictonary();  
    }
    private void Start() {
        SpecialUnityEvent.Instance.doTransform.AddListener(UpdatePoolingToSpawn);
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

    void UpdatePoolingToSpawn(int levelTarget) {
        GameUltis.ReplaceArrayElements(spawnablesList[0].spawnObjectsArray, spawnablesList[levelTarget].spawnObjectsArray);
        UpdateDictonary();
    }
    void UpdateDictonary() {
        spawnableObjectsDict = new Dictionary<ObjectToSpawn, GameObject>();
        foreach (var item in spawnablesList[0].spawnObjectsArray) {
            spawnableObjectsDict.Add(item.key, item.value);
        }
    }
}
