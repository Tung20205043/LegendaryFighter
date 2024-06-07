using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameUltis;

public class CharChooseVsMode : MonoBehaviour {
    [SerializeField] Button nextButton;
    [SerializeField] Button undoButton;
    [SerializeField] CharChooseControl[] charChooseControls;

    [SerializeField] GameObject[] playerUi;
    [SerializeField] GameObject[] enemyUi;
    [SerializeField] GameObject enemyDefaultUi;

    [SerializeField] private GameObject unlockPanel;
    [SerializeField] private TextMeshProUGUI coinValue;
    protected void Awake() {
        nextButton.onClick.AddListener(OnclickNextButton);
        undoButton.onClick.AddListener(OnclickUndoButton);
    }
    private void Start() {
        SpecialUnityEvent.Instance.changePlayerChoose.AddListener(ChangeImg);
        SpecialUnityEvent.Instance.setActiveUnlockPanel.AddListener(SetActiveUnlockPanel);
    }
    private void OnEnable() {
        CharChooseUI.SetPlayerChooseTurn();
        Hide(undoButton.gameObject);
        charChooseControls[(int)GameManager.Instance.playerChosen].ChangePlayerChosen();
        ShowObjInArray((int)GameManager.Instance.playerChosen, playerUi);
        SetDefaultEnemyUI();
    }
    void OnclickNextButton() {
        if (CharChooseUI.isPlayerChooseTurn) {
            Show(undoButton.gameObject);
            CharChooseUI.isPlayerChooseTurn = false;
            PickRamdomEnemy();
        } else {
            // Test
            if (GameManager.Instance.gameMode != GameMode.Train) return;

            SceneManager.LoadScene(1);
            
        }
    }
    void OnclickUndoButton() {
        CharChooseUI.isPlayerChooseTurn = true;
        foreach (var control in charChooseControls) {
            control.Undo();
        }
        SetDefaultEnemyUI();
    }
    void ChangeImg(CharacterToChoose characterToChoose) {
        ShowObjInArray((int)characterToChoose, CharChooseUI.isPlayerChooseTurn ? playerUi : enemyUi);
        if (!CharChooseUI.isPlayerChooseTurn && enemyDefaultUi.activeSelf) 
            Hide(enemyDefaultUi);
    }
    void SetDefaultEnemyUI() {
        foreach (var ui in enemyUi) {
            Hide(ui);
        }
        Show(enemyDefaultUi);
    }
    void PickRamdomEnemy() {
        int ramdomValue = GenerateRandomValue(0, charChooseControls.Length - 1, CharacterCannotRandom());
        charChooseControls[ramdomValue].ChangePlayerChosen();
    }

    private int[] CharacterCannotRandom()
    {
        int playerChosenInt = (int)GameManager.Instance.playerChosen;
        List<int> characterNotUnlockedIntList = CharUnlockManager.Instance.CharacterNotUnlocked.Select(character => (int)character).ToList();
        int[] combinedArray = new int[characterNotUnlockedIntList.Count + 1];
        combinedArray[0] = playerChosenInt;
        for (int i = 0; i < characterNotUnlockedIntList.Count; i++)
        {
            combinedArray[i + 1] = characterNotUnlockedIntList[i];
        }

        return combinedArray;
    }

    private void SetActiveUnlockPanel(int value)
    {
        Show(unlockPanel);
        coinValue.text = FormatNumber(value);
    }

}
