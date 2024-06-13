using UnityEngine;
using UnityEngine.UI;
using static GameUltis;

public class SettingUI : MonoBehaviour {
    [SerializeField] Button xButton;
    [SerializeField] Button[] OnOffButton;
    [SerializeField] Button controlButton;
    [SerializeField] GameObject baseControl;

    [SerializeField] private Animator[] onOffAnim;
    private void Awake() {
        xButton.onClick.AddListener(() => this.gameObject.SetActive(false));
        OnOffButton[0].onClick.AddListener(() => OnclickButton(0));
        OnOffButton[1].onClick.AddListener(() => OnclickButton(1));
        OnOffButton[2].onClick.AddListener(() => OnclickButton(2));
        OnOffButton[3].onClick.AddListener(() => OnclickButton(3));

        controlButton.onClick.AddListener(() => Show(baseControl));
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
                onOffAnim[2].SetBool("On", !GameManager.Instance.onNotify);
                GameManager.Instance.onNotify = !GameManager.Instance.onNotify;
                break;
            case 3:
                onOffAnim[3].SetBool("On", !GameManager.Instance.onHaptic);
                GameManager.Instance.onHaptic = !GameManager.Instance.onHaptic;
                break;
        }
    }
}
