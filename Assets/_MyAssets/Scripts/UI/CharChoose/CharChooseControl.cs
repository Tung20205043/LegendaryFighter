using UnityEngine;
using UnityEngine.UI;

public class CharChooseControl : MonoBehaviour {
    public CharacterToChoose characterToChoose;
    private Button thisButton;
    [SerializeField] GameObject blueFrame;
    [SerializeField] GameObject yellowFrame;

    private void Awake() {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(ChangePlayerChosen);
        SpecialUnityEvent.Instance.changePlayerChoose.AddListener(ListenOnetherChosen);
    }
    public void ChangePlayerChosen() {
        if (CharChooseUI.isPlayerChooseTurn) {
            GameManager.Instance.playerChosen = this.characterToChoose;
            blueFrame.SetActive(true);
            SpecialUnityEvent.Instance.changePlayerChoose?.Invoke(characterToChoose);
        } 
        else {
            if (GameManager.Instance.playerChosen == this.characterToChoose) return;
            GameManager.Instance.enemyChosen = this.characterToChoose;
            yellowFrame.SetActive(true);
            SpecialUnityEvent.Instance.changePlayerChoose?.Invoke(characterToChoose);
        }
    }
    void ListenOnetherChosen(CharacterToChoose charChoose) {
        if (charChoose != this.characterToChoose) {
            if (CharChooseUI.isPlayerChooseTurn) {
                this.blueFrame.SetActive(false);
            } else {
                this.yellowFrame.SetActive(false);
            }
        }
    }
    public void Undo() { 
        this.yellowFrame.SetActive(false);
    }
    private void OnDisable() {
        this.blueFrame.SetActive(false);
        this.yellowFrame.SetActive(false);
    }
}
