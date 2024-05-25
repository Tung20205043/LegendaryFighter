using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheel : MonoBehaviour {
    [Header("Wheel number")]
    public int numberGift = 8;
    public float timeRotate;
    public float numberRotate;

    private const float CIRCLE = 360.0f;
    private float angelOfOneGift;

    private float currentTime;
    public AnimationCurve curve;
    [Header("Button - UI")]
    [SerializeField] private Button SpinButton;

    [SerializeField] Sprite[] imgSprite;
    int priceValue = 1;
    private void Awake() {
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
        priceValue += indexGiftRandom - 1;
        if (priceValue > numberGift) {
            priceValue = priceValue - 8;
        }

        float angelToRotate = (numberRotate * CIRCLE) + angelOfOneGift * indexGiftRandom;
        while (currentTime < timeRotate) {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            float angelCurrent = angelToRotate * curve.Evaluate(currentTime / timeRotate);
            this.transform.eulerAngles = new Vector3(0, 0, angelCurrent + startAngel);
        }
        TakeResult(priceValue);
    }


    void TakeResult(int result) {
        Debug.Log(result);
        switch (result) {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
        }
    }
}
