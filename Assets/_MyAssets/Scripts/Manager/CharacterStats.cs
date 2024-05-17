using UnityEngine;

public class CharacterStats : MonoBehaviourSingleton<CharacterStats> 
{

    [Header("Player Stat")]
    [SerializeField] private int playerLevel = 1;
    [SerializeField] private float playerAtk = 10f;
    [SerializeField] private float playerHp = 100f;
    [SerializeField] private float playerMana = 100f;

    [Header("Enemy Stat")]
    [SerializeField] private int enemyLevel = 1;
    [SerializeField] private float enemyAtk = 10f;
    [SerializeField] private float enemyHp = 100f;
    [SerializeField] private float enemyMana = 100f;

    [SerializeField] private float previousEnemyLevel = 1;

    public int PlayerLevel => playerLevel;
    public float PlayerAtk => playerAtk;
    public float PlayerHp => playerHp;
    public float PlayerMana => playerMana;

    public int EnemyLevel => enemyLevel;
    public float EnemyAtk => enemyAtk;
    public float EnemyHp => enemyHp;
    public float EnemyMana => enemyMana;
    [Header("Max Stat")]
    public float maxPlayerHp = 100f;
    public float maxPlayerMana = 100f;

    public float maxEnemyHp = 100f;
    public float maxEnemyMana = 100f;
    [Header("")]
    public float startCharacterAtk = 10f;
    public float startHp = 100f;
    private bool  isPlayerBuff;
    private bool isEnemyBuff;
    private void Update() {
        if (isPlayerBuff) {
            if (IsMaxMana(Character.Player)) return;
            playerMana += 15 * Time.deltaTime; 
        }
        if (isEnemyBuff) {
            if (IsMaxMana(Character.Enemy)) return;
            enemyMana += 15 * Time.deltaTime; 
        }
    }
    public void StartGame() {
        playerMana = 50;
        enemyMana = 50;
        playerHp = maxPlayerHp;
        enemyHp = maxEnemyHp;
    }
    public void ChangeBuffManaState(bool onBuff, Character character) {
        if (character == Character.Player) {
            isPlayerBuff = onBuff;
        } else if (character == Character.Enemy) {
            isEnemyBuff = onBuff;
        }
    }
    public void TakeDamage(Character character, float amount) {
        switch (character) {
            case Character.Player:
                playerHp -= amount;
                if (playerHp < 0) playerHp = 0;
                break;
            case Character.Enemy:
                enemyHp -= amount;
                if (enemyHp < 0) enemyHp = 0;
                break;
        }
    }
    public void PayMana(Character character, float amount) {
        switch (character) {
            case Character.Player:
                playerMana -= amount;
                if (playerMana < 0) playerMana = 0;
                break;
            case Character.Enemy:
                enemyMana -= amount;
                if (enemyMana < 0) enemyMana = 0;
                break;
        }
    }
    public bool IsMaxMana(Character character) {
        return (character == Character.Player) ? playerMana >= maxPlayerMana : enemyMana >= maxEnemyMana;
    }
    
}
