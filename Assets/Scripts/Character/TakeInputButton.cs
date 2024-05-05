using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TakeInputButton : MonoBehaviour
{
    [SerializeField] Button buffManaButton;
    [SerializeField] Button levelUpButton;
    [SerializeField] Button[] attackButton;
    [SerializeField] Button dashButton;
    [SerializeField] Button defendButton;

    public UnityEvent<bool> isBuffingMana;
    public UnityEvent isDashing;
    private void Awake() {
        dashButton.onClick.AddListener(Dashing);
    }

    public void BuffingMana() {
        isBuffingMana?.Invoke(true);
    }
    public void StopBuffMana() { 
        isBuffingMana?.Invoke(false);
    }

    public void Dashing() {
        isDashing?.Invoke();
    }
}
