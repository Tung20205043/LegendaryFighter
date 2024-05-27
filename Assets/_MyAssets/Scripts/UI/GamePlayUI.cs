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
