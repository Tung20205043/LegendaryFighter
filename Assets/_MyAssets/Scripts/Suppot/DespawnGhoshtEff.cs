using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnGhoshtEff : MonoBehaviour
{
    private void OnEnable() {
        StartCoroutine(DespawnThisGameObj());
    }
    IEnumerator DespawnThisGameObj() { 
        yield return new WaitForSeconds(1.5f);
        ObjectPoolingForGoku.Instance.DeSpawn(this.gameObject);
    }
}
