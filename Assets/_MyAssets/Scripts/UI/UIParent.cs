using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIParent : MonoBehaviour
{
    [SerializeField] protected Button backButton;
    protected virtual void Awake() {
        backButton.onClick.AddListener(() => SpecialUnityEvent.Instance.backToMainUI?.Invoke());
    }
}
