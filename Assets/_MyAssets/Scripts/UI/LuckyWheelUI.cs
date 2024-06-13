using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LuckyWheelUI : UIParent
{
    [Header("Wheel number")]
    public int numberGift = 8;
    public float timeRotate;
    public float numberRotate;

    private const float CIRCLE = 360.0f;
    private float angelOfOneGift;

    private float currentTime;
    public AnimationCurve curve;
    [Header("Button - UI")]
    [SerializeField] Button SpinButton;
    [SerializeField] TextMeshProUGUI rewardValue;
    [SerializeField] GameObject notice;
    int priceValue = 1;
    protected override void Awake() {
        base.Awake();
        SpinButton.onClick.AddListener(DoRotateWheel);
    }
    private void Start() {
        angelOfOneGift = CIRCLE / numberGift;

    }
    void DoRotateWheel() {
        StartCoroutine(RotateWheel());
    }
    IEnumerator RotateWheel() {
        float startAngel = transform.eulerAngles.z;
        currentTime = 0;

        int indexGiftRandom = Random.Range(1, numberGift + 1);
        priceValue += indexGiftRandom;
        if (priceValue > numberGift) {
            priceValue = priceValue - numberGift;
        }

        float angelToRotate = (numberRotate * CIRCLE) + angelOfOneGift * indexGiftRandom;
        while (currentTime < timeRotate) {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            float angelCurrent = angelToRotate * curve.Evaluate(currentTime / timeRotate);
            this.transform.localEulerAngles = new Vector3(0, 0, angelCurrent + startAngel);
        }
        TakeResult(priceValue);
    }
    void TakeResult(int result) {
        notice.SetActive(true);
        rewardValue.text = GameConstant.rewardValue[result - 1].ToString();
        CoinText.plusCoin = GameConstant.rewardValue[result - 1];
    }

}
