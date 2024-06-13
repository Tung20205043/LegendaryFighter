using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GameUltis;
public class NoticeUI : MonoBehaviour
{
    [SerializeField] private Button okButton;
    [SerializeField] private TextMeshProUGUI playerName;

    protected virtual void Awake() {
        okButton.onClick.AddListener(OnclickOkButton);
    }
    protected virtual void OnclickOkButton() {
        this.gameObject.SetActive(false);
    }
    
    [System.Serializable]
    public class UIObject {
        public CharacterToChoose key;
        public GameObject imgs;
        public string charName;
    }
    [SerializeField] private List<UIObject> uIObjectList;

    private void OnEnable() {
        SpecialUnityEvent.Instance.unlockCharacter.AddListener(ShowUI);
    }
    private void ShowUI(CharacterToChoose characterToChoose)
    {
        foreach (var uiObj in uIObjectList.Where(uiObj => uiObj.key.Equals(characterToChoose)))
        {
            Show(uiObj.imgs);
            playerName.text = uiObj.charName;
        }
    }
    private void OnDisable()
    {
        foreach (var uiObj in uIObjectList)
        {
            Hide(uiObj.imgs);
        }
    }
}
