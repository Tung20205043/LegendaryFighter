using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static GameUltis;
public class PausePanelUI : MonoBehaviour
{
    [SerializeField] Button exitButton;
    [SerializeField] Button resumeButton;
    [SerializeField] Button controlButton;

    [SerializeField] GameObject baseControlPanel;
    [SerializeField] GameObject gameUI;

    [SerializeField] Button[] OnOffButton;
    [SerializeField] private Animator[] onOffAnim;
    private void Awake() {
        exitButton.onClick.AddListener(ExitGame);
        resumeButton.onClick.AddListener(ContinueGame);
        controlButton.onClick.AddListener(() => Show(baseControlPanel));

        OnOffButton[0].onClick.AddListener(() => OnclickButton(0));
        OnOffButton[1].onClick.AddListener(() => OnclickButton(1));
        OnOffButton[2].onClick.AddListener(() => OnclickButton(2));
    }
    void ContinueGame() {
        DoContinue();
    }
    void ExitGame() {
        DoContinue();
        SceneManager.LoadScene(0);
    }
    void DoContinue() {
        Time.timeScale = 1.0f;
        Hide(this.gameObject);
        Show(gameUI);
    }
    void OnclickButton(int i) {
        switch (i) {
            case 0:
                onOffAnim[0].SetBool("On", !GameManager.Instance.onMusic);
                GameManager.Instance.onMusic = !GameManager.Instance.onMusic;
                break;
            case 1:
                onOffAnim[1].SetBool("On", !GameManager.Instance.onSound);
                GameManager.Instance.onSound = !GameManager.Instance.onSound;
                break;
            case 2:
                onOffAnim[2].SetBool("On", !GameManager.Instance.onHaptic);
                GameManager.Instance.onHaptic = !GameManager.Instance.onHaptic;
                break;
        }
    }
}
