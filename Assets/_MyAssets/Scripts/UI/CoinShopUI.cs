using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinShopUI : UIParent
{
    [SerializeField] Button[] payButton;
    [SerializeField] GameObject notiObj;
    protected override void Awake() {
        base.Awake();
        for(int i = 0; i < payButton.Length; i++) {
           payButton[i].onClick.AddListener(() => notiObj.SetActive(true));
        }
    }
}
