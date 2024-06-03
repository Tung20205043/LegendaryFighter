using static GameUltis;
using UnityEngine;
using UnityEngine.UI;

public class FighterPanelController : MonoBehaviour
{
    [SerializeField] GameObject[] playerUi;
    [SerializeField] CharChooseControl[] charChooseControls;
    [SerializeField] GameObject tourPanelBackButton;
    [SerializeField] Button thisBackButton;
    [SerializeField] Button okButton;
    [SerializeField] GameObject tourPanel;
    private void Awake() {
        thisBackButton.onClick.AddListener(OnclickOkButton);
        okButton.onClick.AddListener(OnclickOkButton);  
    }
    private void Start() {
        SpecialUnityEvent.Instance.changePlayerChoose.AddListener(ChangeImg);
    }
    private void OnEnable() {
        CharChooseUI.SetPlayerChooseTurn();
        charChooseControls[(int)GameManager.Instance.playerChosen].ChangePlayerChosen();
        Hide(tourPanelBackButton.gameObject);
    }
    void ChangeImg(CharacterToChoose characterToChoose) {
        ShowObjInArray((int)characterToChoose, playerUi);
    }
    void OnclickOkButton() { 
        Hide(this.gameObject);
        Show(tourPanelBackButton);
        Show(tourPanel);
        SpecialUnityEvent.Instance.newTourGame?.Invoke();
    }
}
