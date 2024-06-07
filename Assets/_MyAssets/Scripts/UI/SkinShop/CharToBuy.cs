using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameUltis;

public class CharToBuy : MonoBehaviour
{
    public CharacterUnlockData characterUnlockData;
    private Button button;
    [SerializeField] GameObject yellowFrame;
    private void Awake() {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeCharBuy);
        SpecialUnityEvent.Instance.changeCharToBuy.AddListener(ListenOnetherChosen);
    }

    private void Update()
    {
        if ((this.characterUnlockData.IsUnlocked))
        {
            Hide(this.gameObject);
        }
    }

    void ListenOnetherChosen(CharacterToChoose charChoose) {
        if (charChoose != this.characterUnlockData.Character) {
            Hide(this.yellowFrame);
        }
        else
        {
            Show(yellowFrame);
        }
    }

    void ChangeCharBuy() {
        SpecialUnityEvent.Instance.changeCharToBuy?.Invoke(this.characterUnlockData.Character);
        SpecialUnityEvent.Instance.charPrice?.Invoke(this.characterUnlockData.Price);
    }


}
