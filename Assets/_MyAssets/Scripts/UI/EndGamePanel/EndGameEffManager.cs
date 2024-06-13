using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameUltis;
public class EndGameEffManager : MonoBehaviour
{
    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject enemyCam;
    private bool _isEndGame;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject pauseButton;

    private void OnEnable()
    {
        _isEndGame = false;
    }

    private void Update()
    {
        if (CharacterStats.Instance.PlayerHp <= 0 && !_isEndGame)
        {
            _isEndGame = true;
            TargetCameraTo(Character.Enemy);
        }
        if (CharacterStats.Instance.EnemyHp <= 0 && !_isEndGame)
        {
            _isEndGame = true;
            TargetCameraTo(Character.Player);
        }
    }

    private void TargetCameraTo(Character character)
    {
        SpecialUnityEvent.Instance.endGame?.Invoke();
        Hide(pauseButton);
        if (character == Character.Player)
        {
            Show(enemyCam);
            SpecialUnityEvent.Instance.enemyIsVictory?.Invoke(false);
            StartCoroutine(SwitchCameraTo(Character.Player));
        }
        else
        {
            Show(playerCam);
            SpecialUnityEvent.Instance.playerIsVictory?.Invoke(false);
            StartCoroutine(SwitchCameraTo(Character.Enemy));
        }
    }

    IEnumerator SwitchCameraTo(Character character)
    {
        yield return new WaitForSeconds(2f);
        if (character == Character.Player)
        {
            Hide(enemyCam);
            Show(playerCam);
            SpecialUnityEvent.Instance.playerIsVictory?.Invoke(true);
            Invoke(nameof(SetActivePanel), 2f);
        }
        else
        {
            Hide(playerCam);
            Show(enemyCam);
            SpecialUnityEvent.Instance.enemyIsVictory?.Invoke(true);
            Invoke(nameof(SetActivePanel), 2f);
        }
    }

    private void SetActivePanel()
    {
        Show(victoryPanel);
    }

    private void OnDisable()
    {
        if (playerCam != null)
        {
            Hide(playerCam);
        }
        if (enemyCam != null)
        {
            Hide(enemyCam);
        }
    }
}
