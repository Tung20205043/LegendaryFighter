using UnityEngine;
using UnityEngine.UI;
using static GameUltis;
public class GamePlayUI : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject ui;
    public bool playerIsReady = false;
    public bool enemyIsReady = false;
    Animator animator;
    private void Awake() {
        pauseButton.onClick.AddListener(SetPauseGame);
        animator = GetComponent<Animator>();
        SpecialUnityEvent.Instance.playerIsReady.AddListener(CheckPlayerReady);
        SpecialUnityEvent.Instance.enemyIsReady.AddListener(CheckEnemyReady);
    }
    private void OnEnable() {
        Hide(pauseButton.gameObject);
        playerIsReady = false;
        enemyIsReady = false;
    }
    void SetPauseGame() {
        Show(pausePanel);
        Time.timeScale = 0f;
        Hide(ui);
    }
    public void ReadyToFight() {
        SpecialUnityEvent.Instance.readyToFight?.Invoke();
        Show(pauseButton.gameObject);
    }
    void CheckPlayerReady() { 
        playerIsReady = true;
        if (!enemyIsReady) return;
        animator.SetTrigger("Ready");
    }
    void CheckEnemyReady() {
        enemyIsReady = true;
        if (!playerIsReady) return;
        animator.SetTrigger("Ready");
    }
    //private void OnDisable() {
    //    playerIsReady = false;
    //    enemyIsReady = false;
    //}
}
