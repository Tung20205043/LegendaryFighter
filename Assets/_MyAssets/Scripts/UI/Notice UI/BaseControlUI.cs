using UnityEngine;
using UnityEngine.UI;
using static GameUltis;
public class BaseControlUI : MonoBehaviour
{
    [SerializeField] GameObject[] guideUI;
    [SerializeField] GameObject[] titles;
    [SerializeField] Button nextButton;
    [SerializeField] Button prevButton;
    [SerializeField] Button xButton;
    int guideValue = 0;
    private void Awake() {
        nextButton.onClick.AddListener(() => ChangeGuide(+1));
        prevButton.onClick.AddListener(() => ChangeGuide(-1));
        xButton.onClick.AddListener(() => Hide(this.gameObject));
    }
    void ChangeGuide(int value) {
        guideValue += value;
        if (guideValue > guideUI.Length - 1)
            guideValue = 0;
        if (guideValue < 0)
            guideValue = guideUI.Length - 1;
        ShowObjInArray(guideValue, guideUI);
        ShowObjInArray(guideValue, titles);   
    }
}
