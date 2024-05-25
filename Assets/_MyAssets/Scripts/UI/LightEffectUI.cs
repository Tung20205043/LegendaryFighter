using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LightEffectUI : MonoBehaviour
{
    private Image img;
    public bool isRed = false;
    public float duration = 0.2f; 

    void Start() {
        img = GetComponent<Image>();

        StartColorChange();
    }

    void StartColorChange() {
        img.DOColor(isRed ? Color.white : Color.red, duration).OnComplete(() => {
            isRed = !isRed;
            StartColorChange();
        });
    }
}
