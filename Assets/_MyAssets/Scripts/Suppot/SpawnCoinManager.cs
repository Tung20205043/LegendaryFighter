using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoinManager : MonoBehaviourSingleton<SpawnCoinManager> 
{
    [SerializeField] Transform[] startPosition;
    [SerializeField] public Transform endPosition;

    private void Start() {
        SpecialUnityEvent.Instance.spawnCoin.AddListener(SpawnCoin);
    }
    protected void SpawnCoin() {  
        StartCoroutine(SpawnObjects());
    }
    IEnumerator SpawnObjects() {
        int spawnCount = 0;
        while (spawnCount < 5) {
            Transform start = startPosition[Random.Range(0, startPosition.Length)];
            ObjectPoolingForCoin.Instance.SpawnObject(start.position, start.localRotation);
            spawnCount++;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
