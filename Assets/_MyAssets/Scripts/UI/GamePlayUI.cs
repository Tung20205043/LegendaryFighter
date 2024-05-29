using UnityEngine;
using UnityEngine.UI;
using static GameUltis;
public class GamePlayUI : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject ui;

    private void Awake() {
        pauseButton.onClick.AddListener(SetPauseGame);
    }
    private void OnEnable() {
        Hide(pauseButton.gameObject);
        Debug.Log(GameManager.Instance.gameDifficult);
        Debug.Log(GameManager.Instance.gameMode);
        Debug.Log(GameManager.Instance.playerChosen);
        Debug.Log(GameManager.Instance.enemyChosen);
        Debug.Log(GameManager.Instance.mapChosen);
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
}
