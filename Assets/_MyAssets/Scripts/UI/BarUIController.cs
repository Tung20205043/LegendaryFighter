using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarUIController : MonoBehaviour {
    [SerializeField] Image playerHealth;
    [SerializeField] Image playerMana;
    [SerializeField] Image enemyHealth;
    [SerializeField] Image enemyMana;
    [SerializeField] TextMeshProUGUI playerHealthText;
    [SerializeField] TextMeshProUGUI playerManaText;
    [SerializeField] TextMeshProUGUI enemyHealthText;
    [SerializeField] TextMeshProUGUI enemyManaText;
    CharacterStats stats;
    private void Start()
    {
        stats = CharacterStats.Instance; 
    }
    private void Update() {
        UpdateImage();
        UpdateTexts();
    }
    private void UpdateTexts() {
        UpdateText(playerHealthText, stats.PlayerHp, stats.maxPlayerHp);
        UpdateText(enemyHealthText, stats.EnemyHp, stats.maxEnemyHp);
        UpdateText(playerManaText, stats.PlayerMana, stats.maxPlayerMana, true);
        UpdateText(enemyManaText, stats.EnemyMana, stats.maxEnemyMana, true);
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
        UpdateStatusBar(playerHealth, stats.PlayerHp, stats.maxPlayerHp);
        UpdateStatusBar(playerMana, stats.PlayerMana, stats.maxPlayerMana);
        UpdateStatusBar(enemyHealth, stats.EnemyHp, stats.maxEnemyHp);
        UpdateStatusBar(enemyMana, stats.EnemyMana, stats.maxEnemyMana);
    }
    private void UpdateStatusBar(Image statusBar, float currentValue, float maxValue) {
        float fillAmountRatio = currentValue / maxValue;
        statusBar.fillAmount = fillAmountRatio;
    }
}
