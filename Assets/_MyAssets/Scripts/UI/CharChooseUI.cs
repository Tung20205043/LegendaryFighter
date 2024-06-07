using TMPro;
using static GameUltis;
using UnityEngine;

public class CharChooseUI : UIParent {
    [SerializeField] GameObject[] charChoosePanels;
    public static bool isPlayerChooseTurn;
    
    [SerializeField] private GameObject unlockPanel;
    [SerializeField] private TextMeshProUGUI coinValue;
    protected override void Awake() {
        base.Awake();
        SpecialUnityEvent.Instance.setActiveUnlockPanel.AddListener(SetActiveUnlockPanel);
    }
    private void OnEnable() {
        ShowObjInArray((int)GameManager.Instance.gameMode, charChoosePanels);

    }
    public static void SetPlayerChooseTurn() { 
        isPlayerChooseTurn = true;
    }
    private void SetActiveUnlockPanel(int value)
    {
        Show(unlockPanel);
        coinValue.text = FormatNumber(value);
    }
}
