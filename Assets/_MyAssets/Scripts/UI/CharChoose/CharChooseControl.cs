using System;
using UnityEngine;
using UnityEngine.UI;
using static GameUltis;
public class CharChooseControl : MonoBehaviour {
    [SerializeField] private CharacterToChoose characterToChoose;
    private Button _thisButton;
    [SerializeField] private GameObject blueFrame;
    [SerializeField] private GameObject yellowFrame;
    [SerializeField] private GameObject lockMask;
    [SerializeField] private CharacterUnlockData characterUnlockData;

    private void Awake() {
        _thisButton = GetComponent<Button>();
        _thisButton.onClick.AddListener(ChangePlayerChosen);
        SpecialUnityEvent.Instance.changePlayerChoose.AddListener(ListenOnetherChosen);
    }

    private void OnEnable()
    {
        SetActiveUI();
    }

    void SetActiveUI()
    {
        if (CharUnlockManager.Instance.IsDefaultCharacter(this.characterToChoose)) return;
        if (!CharUnlockManager.Instance.IsCharacterUnlocked(this.characterToChoose))
        {
            Show(lockMask);
        }
        else
        {
            Hide(lockMask);
        }
    }

    public void ChangePlayerChosen() {
        if (ThisCharacterIsLock())
        {
            SpecialUnityEvent.Instance.setActiveUnlockPanel?.Invoke(this.characterUnlockData.Price);
            return;
        }
        if (CharChooseUI.isPlayerChooseTurn) {
            PlayerTurnToPick();
        } 
        else {
            EnemyTurnToPick();
        }
    }

    private void PlayerTurnToPick()
    {
        GameManager.Instance.ChangePlayerChosen(this.characterToChoose);
        Show(this.blueFrame);
        SpecialUnityEvent.Instance.changePlayerChoose?.Invoke(characterToChoose);
    }

    private void EnemyTurnToPick()
    {
        if (GameManager.Instance.PlayerChosen == this.characterToChoose) return;
        GameManager.Instance.ChangerEnemyChosen(this.characterToChoose);
        Show(this.yellowFrame);
        SpecialUnityEvent.Instance.changePlayerChoose?.Invoke(characterToChoose);
    }
    private void ListenOnetherChosen(CharacterToChoose charChoose)
    {
        if (charChoose == this.characterToChoose) return;
        Hide(CharChooseUI.isPlayerChooseTurn ? this.blueFrame : this.yellowFrame);
    }
    public void Undo() { 
        Hide(this.yellowFrame);
    }
    private void OnDisable() {
        Hide(this.blueFrame);
        Hide(this.yellowFrame);
    }

    private bool ThisCharacterIsLock()
    {
        return !CharUnlockManager.Instance.IsCharacterUnlocked(this.characterToChoose) 
               && !CharUnlockManager.Instance.IsDefaultCharacter(this.characterToChoose);
    }
}
