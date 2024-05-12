using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static CharacterStats;

public class BarUIController : MonoBehaviour {
    [SerializeField] Image playerHealth;
    [SerializeField] Image playerMana;
    [SerializeField] Image enemyHealth;
    [SerializeField] Image enemyMana;
    [SerializeField] TextMeshProUGUI playerHealthText;
    [SerializeField] TextMeshProUGUI playerManaText;
    [SerializeField] TextMeshProUGUI enemyHealthText;
    [SerializeField] TextMeshProUGUI enemyManaText;
    private void Update() {
        UpdateImage();
        UpdateTexts();
    }
    private void UpdateTexts() {
        UpdateText(playerHealthText, Instance.PlayerHp, Instance.maxPlayerHp);
        UpdateText(enemyHealthText, Instance.EnemyHp, Instance.maxEnemyHp);
        UpdateText(playerManaText, Instance.PlayerMana, Instance.maxPlayerMana, true);
        UpdateText(enemyManaText, Instance.EnemyMana, Instance.maxEnemyMana, true);
    }

    private void UpdateText(TextMeshProUGUI text, float currentValue, float maxValue) {
        text.text = $"{Mathf.RoundToInt(currentValue)}/{maxValue}";
    }

    private void UpdateText(TextMeshProUGUI text, float currentValue, float maxValue, bool roundToInt) {
        float displayValue = currentValue / maxValue * 100f;
        if (roundToInt) {
            displayValue = Mathf.RoundToInt(displayValue);
        }
        text.text = $"{displayValue}%";
    }

    void UpdateImage() {
        UpdateStatusBar(playerHealth, Instance.PlayerHp, Instance.maxPlayerHp);
        UpdateStatusBar(playerMana, Instance.PlayerMana, Instance.maxPlayerMana);
        UpdateStatusBar(enemyHealth, Instance.EnemyHp, Instance.maxEnemyHp);
        UpdateStatusBar(enemyMana, Instance.EnemyMana, Instance.maxEnemyMana);
    }
    private void UpdateStatusBar(Image statusBar, float currentValue, float maxValue) {
        float fillAmountRatio = currentValue / maxValue;
        statusBar.fillAmount = fillAmountRatio;
    }
}
