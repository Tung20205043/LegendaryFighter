using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharChooseControl : MonoBehaviour
{
    public CharacterToChoose characterToChoose;
    private Button thisButton;
    [SerializeField] GameObject blueFrame;
    [SerializeField] GameObject yellowFrame;
    private void Awake() {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(ChangePlayerChosen);
        SpecialUnityEvent.Instance.changePlayerChoose.AddListener(ListenOnetherChosen);
    }
    void ChangePlayerChosen() { 
        GameManager.Instance.playerChosen = characterToChoose;
        blueFrame.SetActive(true);
        SpecialUnityEvent.Instance.changePlayerChoose?.Invoke(characterToChoose);
    }
    void ListenOnetherChosen(CharacterToChoose playerChoose) {
        if (playerChoose != this.characterToChoose) { 
            this.blueFrame.SetActive(false);
        }
    }
}
