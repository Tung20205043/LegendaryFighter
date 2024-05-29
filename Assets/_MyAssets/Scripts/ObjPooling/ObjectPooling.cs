using System.Collections.Generic;
using UnityEngine;
using static GameUltis;

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
                    SetParent(poolObj, parentToSpawn);
                    poolObj.transform.position = spawnPoin;
                    poolObj.transform.rotation = spawnRotation;
                    Show(poolObj);
                    return;
                }
            }
        }
        GameObject newPoolObj = Instantiate(_poolObj, spawnPoin, spawnRotation, parentToSpawn);
        newPoolObj.name = _poolObj.name;
        newPoolObj.transform.SetParent(parentToSpawn, false);

    }
    public void DeSpawn(GameObject _poolObj) {
        poolObj.Add(_poolObj);
        Hide(_poolObj);
        SetParent(_poolObj, holder);
    }
}
