using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameModeUI : UIParent {
    [SerializeField] private Button[] modeButtonOff;
    [SerializeField] private GameObject[] modeButtonOn;
    [SerializeField] private GameObject[] modeUI;
    [SerializeField] private GameObject[] difficultUI;
    [SerializeField] private Button difficultButton;

    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject charChoose;
    private int difficultValue = 0;
    private int modeValue;
    [SerializeField] private TextMeshProUGUI rewardText;

    protected override void Awake() {
        base.Awake();
        modeButtonOff[0].onClick.AddListener(() => OnClickModeButton(0));
        modeButtonOff[1].onClick.AddListener(() => OnClickModeButton(1));
        modeButtonOff[2].onClick.AddListener(() => OnClickModeButton(2));
        modeButtonOff[3].onClick.AddListener(() => OnClickModeButton(3));
        difficultButton.onClick.AddListener(ChangeDifficult);
        nextButton.onClick.AddListener(OnclickNextButton);
    }
    private void OnEnable() {
        SetDifficultUI(GameDifficult.Medium);
    }

    void OnClickModeButton(int chooseNum) {
        modeValue = chooseNum;
        for (int i = 0; i < modeUI.Length; i++) {
            modeButtonOff[i].gameObject.SetActive(true);
        }
        modeButtonOff[chooseNum].gameObject.SetActive(false);
        SetActiveOneObjInArray(modeUI, chooseNum);
        SetActiveOneObjInArray(modeButtonOn, chooseNum);
        GameManager.Instance.ChangeGameMode((GameMode)modeValue);
    }
    void ChangeDifficult() {
        difficultValue++;
        if (difficultValue > difficultUI.Length - 1)
            difficultValue = 0;
        SetDifficultUI((GameDifficult)difficultValue);
    }
    private void SetDifficultUI(GameDifficult difficult)
    {
        difficultValue = (int)difficult;
        GameManager.Instance.ChangeGameDifficult(difficult);
        SetActiveOneObjInArray(difficultUI, (int)difficult);
        rewardText.text = "x" + GameConstant.rewardDifficult[(int)difficult];
    }
    void SetActiveOneObjInArray(GameObject[] array, int chooseNum)
    {
        foreach (var t in array)
            t.SetActive(false);

        array[chooseNum].gameObject.SetActive(true);
    }
    void OnclickNextButton() {
        SpecialUnityEvent.Instance.pressNextButton?.Invoke(charChoose);
    }
}
