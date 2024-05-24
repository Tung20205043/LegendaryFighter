using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeUI : MonoBehaviour
{
    [SerializeField] Button okButton;

    private void Awake() {
        okButton.onClick.AddListener(() => this.gameObject.SetActive(false));
    }
}
