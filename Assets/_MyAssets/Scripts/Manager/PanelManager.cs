using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] GameObject luckyWheel;
    [SerializeField] GameObject coinShop;
    [SerializeField] GameObject skinShop;
    [SerializeField] GameObject gameMode;
    [SerializeField] GameObject characterChoose;
    [SerializeField] GameObject settingPanel;
    [Header("Button")]
    [SerializeField] Button luckyWheelButton;
    [SerializeField] Button saleButton;
    [SerializeField] Button settingButton;
    [SerializeField] Button coinsButton;
    [SerializeField] Button plusCoinButton;
    [SerializeField] Button playButton;
    [SerializeField] Button skinButton;

    Stack<GameObject> panelStack = new Stack<GameObject>();
    private void Awake() {
        luckyWheelButton.onClick.AddListener(() => OnclickButton(luckyWheel));
        saleButton.onClick.AddListener(() => OnclickButton(coinShop)); 
        coinsButton.onClick.AddListener(() => OnclickButton(coinShop)); 
        plusCoinButton.onClick.AddListener(() => OnclickButton(coinShop));
        skinButton.onClick.AddListener(() => OnclickButton(skinShop));
        playButton.onClick.AddListener(() => OnclickButton(gameMode));
        settingButton.onClick.AddListener(() => settingPanel.gameObject.SetActive(true));
    }
    private void Start() {
        SpecialUnityEvent.Instance.backToMainUI.AddListener(BackToMain);
        SpecialUnityEvent.Instance.pressNextButton.AddListener(OnclickButton);
    }
    void OnclickButton(GameObject objToSetActive) {
        if (panelStack.Contains(objToSetActive)) return;
        SetActiveUI(false);
        if (panelStack.Count > 0) {
            GameObject objToDisable = panelStack.Peek();
            objToDisable.SetActive(false);
        }
        objToSetActive.SetActive(true);
        panelStack.Push(objToSetActive);
    }

    void BackToMain() {
        if (panelStack.Count == 1) {
            SetActiveUI(true);
        }
        GameObject objToDisable = panelStack.Pop();
        objToDisable.SetActive(false);
        if (panelStack.Count >= 1) {
            GameObject objToEnable = panelStack.Peek();
            objToEnable.SetActive(true);
        }
    }
    void SetActiveUI(bool active) {
        luckyWheelButton.gameObject.SetActive(active);
        saleButton.gameObject.SetActive(active);
        coinsButton.gameObject.SetActive(active);
        playButton.gameObject.SetActive(active);
        skinButton.gameObject.SetActive(active);
    }
}
