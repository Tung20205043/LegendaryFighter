using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPoolingForCharacter;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] Transform holder;
    [SerializeField] protected List<GameObject> poolObj;
    [SerializeField] protected Transform parentToSpawn;
    public void GetObjectFromBool(GameObject _poolObj, Vector3 spawnPoin, Quaternion spawnRotation) {
        if (poolObj.Count > 0) {
            foreach (GameObject poolObj in poolObj) {
                if (poolObj.name == _poolObj.name) {
                    this.poolObj.Remove(poolObj);
                    poolObj.transform.parent = parentToSpawn;
                    poolObj.transform.position = spawnPoin;
                    poolObj.transform.rotation = spawnRotation;
                    poolObj.SetActive(true);
                    return;
                }
            }
        }
        GameObject newPoolObj = Instantiate(_poolObj, spawnPoin, spawnRotation, parentToSpawn);
        newPoolObj.name = _poolObj.name;
        newPoolObj.transform.parent = parentToSpawn;

    }
    public void DeSpawn(GameObject _poolObj) {
        poolObj.Add(_poolObj);
        _poolObj.SetActive(false);
        _poolObj.transform.parent = holder;
    }
}
