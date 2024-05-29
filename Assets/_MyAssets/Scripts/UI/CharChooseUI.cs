using static GameUltis;
using UnityEngine;

public class CharChooseUI : UIParent {
    [SerializeField] GameObject[] charChoosePanels;
    public static bool isPlayerChooseTurn;
    protected override void Awake() {
        base.Awake();
    }
    private void OnEnable() {
        ShowObjInArray((int)GameManager.Instance.gameMode, charChoosePanels);

    }
    public static void SetPlayerChooseTurn() { 
        isPlayerChooseTurn = true;
    }
}
