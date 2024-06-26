using System.Collections;
using UnityEngine;

public class DespawnGhoshtEff : MonoBehaviour
{
    private void OnEnable() {
        StartCoroutine(DespawnThisGameObj());
    }
    IEnumerator DespawnThisGameObj() { 
        yield return new WaitForSeconds(1.5f);
        ObjectPoolingForCharacter.Instance.DeSpawn(this.gameObject);
    }
}
