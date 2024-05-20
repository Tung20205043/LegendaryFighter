using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveHeavyPunchButton : MonoBehaviour
{
    [SerializeField] private float timeDisable = 0.6f;
    void OnEnable() {
        StartCoroutine(DisableButton());
    }
    IEnumerator DisableButton() {
        yield return new WaitForSeconds(timeDisable);
        this.gameObject.SetActive(false);
    }
}
