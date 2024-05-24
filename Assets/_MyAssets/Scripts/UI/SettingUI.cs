using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] Button xButton;

    private void Awake() {
        xButton.onClick.AddListener(() => this.gameObject.SetActive(false));
    }
}
