using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeUI : MonoBehaviour
{
    [SerializeField] Button okButton;

    protected virtual void Awake() {
        okButton.onClick.AddListener(OnclickOkButton);
    }
    protected virtual void OnclickOkButton() {
        this.gameObject.SetActive(false);
    }
}
