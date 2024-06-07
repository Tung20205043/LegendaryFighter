using static GameUltis;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.Events;

public class CharChooseTour : MonoBehaviour
{
    [SerializeField] Button resetButton;
    [SerializeField] Button playButton;

    [SerializeField] GameObject tourPanel;
    [SerializeField] GameObject fighterPanel;

    [SerializeField] AvtImgTourController[] enemyAvtImg;
    [SerializeField] AvtImgTourController playerAvtImg;

    [SerializeField] private GameObject settingCoinObj;
    private void Awake() {
        resetButton.onClick.AddListener(OnclickResetButton);
    }
    private void Start() {
        SpecialUnityEvent.Instance.newTourGame.AddListener(SetNewGame);
    }
    private void OnEnable() {
        CharChooseUI.SetPlayerChooseTurn();
        Show(tourPanel);
        Hide(fighterPanel);
        SetNewGame();
    }
    void SetNewGame() {
        SetRandomEnemy();
        SetPlayer();
    }
    void OnclickResetButton() {
        Show(fighterPanel);
        Hide(tourPanel);
        Hide(settingCoinObj);
    }
    void SetPlayer() {
        playerAvtImg.ShowImg(GameManager.Instance.playerChosen);
    }
    void SetRandomEnemy() {
        CharacterToChoose[] characters = GenerateRandomCharacters(enemyAvtImg.Length);
        for (int i = 0; i < enemyAvtImg.Length; i++) {
            enemyAvtImg[i].ShowImg(characters[i]);
        }
    }

    public static CharacterToChoose[] GenerateRandomCharacters(int numberOfCharacters) {
        List<CharacterToChoose> allCharacters = new List<CharacterToChoose>(
            ((CharacterToChoose[])Enum.GetValues(typeof(CharacterToChoose)))
            .Where(character => character != CharacterToChoose.Default)
        );
        CharacterToChoose[] randomCharacters = new CharacterToChoose[numberOfCharacters];

        for (int i = 0; i < numberOfCharacters; i++) {
            int playerIndex = (int)GameManager.Instance.playerChosen;
            int randomIndex = GenerateRandomValue(0, allCharacters.Count - 1, new int[] { playerIndex });
            randomCharacters[i] = allCharacters[randomIndex];
            allCharacters.RemoveAt(randomIndex); 
        }

        return randomCharacters;
    }
}
