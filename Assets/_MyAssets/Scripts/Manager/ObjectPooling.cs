using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] GameObject[] objectToSpawn;
    [SerializeField] Transform[] parentToSpawn;
    [SerializeField] Transform holder;
    [SerializeField] protected List<GameObject> poolObj;

    public void SpawnObject(int objectSpawnNum, Vector3 spawnPoint, Quaternion spawnRotation, int parentObjValue) {
        GetObjectFromBool(objectToSpawn[objectSpawnNum], spawnPoint, spawnRotation, parentObjValue);
    }

    protected void GetObjectFromBool(GameObject _poolObj, Vector3 spawnPoin, Quaternion spawnRotation, int parentObjValue) {
        if (poolObj.Count > 0) {
            foreach (GameObject poolObj in poolObj) {
                if (poolObj.name == _poolObj.name) {
                    this.poolObj.Remove(poolObj);
                    poolObj.transform.parent = parentToSpawn[parentObjValue];
                    poolObj.transform.position = spawnPoin;
                    poolObj.transform.rotation = spawnRotation;
                    poolObj.SetActive(true);
                    return;
                }
            }
        }
        GameObject newPoolObj = Instantiate(_poolObj, spawnPoin, spawnRotation, parentToSpawn[parentObjValue]);
        newPoolObj.name = _poolObj.name;
        newPoolObj.transform.parent = parentToSpawn[parentObjValue];

    }
    public void DeSpawn(GameObject _poolObj) {
        poolObj.Add(_poolObj);
        _poolObj.SetActive(false);
        _poolObj.transform.parent = holder;
    }

}