using static GameUltis;
using UnityEngine;

public class CharChooseBossMode : MonoBehaviour
{
    [SerializeField] GameObject[] playerUi;
    [SerializeField] CharChooseControl[] charChooseControls;
    private void Start() {
        SpecialUnityEvent.Instance.changePlayerChoose.AddListener(ChangeImg);
    }
    private void OnEnable() {
        CharChooseUI.SetPlayerChooseTurn();
        charChooseControls[(int)GameManager.Instance.playerChosen].ChangePlayerChosen();
    }
    void ChangeImg(CharacterToChoose characterToChoose) {
        ShowObjInArray((int)characterToChoose, playerUi);
    }
}
