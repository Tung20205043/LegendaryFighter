using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameModeUI : UIParent {
    [SerializeField] Button[] modeButtonOff;
    [SerializeField] GameObject[] modeButtonOn;
    [SerializeField] GameObject[] modeUI;
    [SerializeField] GameObject[] difficultUI;
    [SerializeField] Button difficultButton;

    [SerializeField] Button nextButton;
    [SerializeField] GameObject charChoose;
    private int difficultValue = 0;
    private int modeValue;
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
        GameManager.Instance.gameDifficult = GameDifficult.Easy;
    }

    void OnClickModeButton(int chooseNum) {
        modeValue = chooseNum;
        for (int i = 0; i < modeUI.Length; i++) {
            modeButtonOff[i].gameObject.SetActive(true);
        }
        modeButtonOff[chooseNum].gameObject.SetActive(false);
        SetActiveOneObjInArray(modeUI, chooseNum);
        SetActiveOneObjInArray(modeButtonOn, chooseNum);
        GameManager.Instance.gameMode = (GameMode)modeValue;
    }
    void ChangeDifficult() {
        difficultValue++;
        if (difficultValue > difficultUI.Length - 1)
            difficultValue = 0;
        SetActiveOneObjInArray(difficultUI, difficultValue);
        GameManager.Instance.gameDifficult = (GameDifficult)difficultValue;
    }
    void SetActiveOneObjInArray(GameObject[] array, int chooseNum) {
        for (int i = 0; i < array.Length; i++)
            array[i].SetActive(false);
        array[chooseNum].gameObject.SetActive(true);
    }
    void OnclickNextButton() {
        SpecialUnityEvent.Instance.pressNextButton?.Invoke(charChoose);
    }
}
