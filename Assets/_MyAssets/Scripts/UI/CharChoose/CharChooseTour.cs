using static GameUltis;
using UnityEngine;
using UnityEngine.UI;

public class CharChooseTour : MonoBehaviour
{
    [SerializeField] Button resetButton;
    [SerializeField] Button playButton;

    [SerializeField] GameObject tourPanel;
    [SerializeField] GameObject fighterPanel;
    private void Awake() {
        resetButton.onClick.AddListener(OnclickResetButton);
    }
    private void OnEnable() {
        CharChooseUI.SetPlayerChooseTurn();
        Show(tourPanel);
        Hide(fighterPanel);
    }

    void OnclickResetButton() {
        Show(fighterPanel);
        Hide(tourPanel);
    }
}
