using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GameUltis;

public class DonotEnoughCoinNotice : MonoBehaviour
{
    [SerializeField] private Button xButton;
    [SerializeField] private Button okButton;
    [SerializeField] private GameObject ShopUI;
    [SerializeField] private TextMeshProUGUI coinText;

    private void Awake()
    {
        xButton.onClick.AddListener(OnclickXButton);
        okButton.onClick.AddListener(OnclickOkButton);
    }

    private void OnEnable()
    {
        coinText.text = FormatNumber(SkinShopUI.price);
    }
    
    private void OnclickXButton()
    {
        Hide(this.gameObject);
    }

    private void OnclickOkButton()
    {
        Hide(this.gameObject);
        SpecialUnityEvent.Instance.goToShopButton?.Invoke(ShopUI);
    }
}
