using static GameUltis;
using UnityEngine;
using UnityEngine.UI;

public class MapChooseController : MonoBehaviour
{
    public MapToChoose thisMapToChoose;
    private Button thisButton;
    [SerializeField] GameObject redFrame;

    private void Awake() {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(ChangerMapChosen);
        SpecialUnityEvent.Instance.changeMapToChoose.AddListener(ListenOnetherChosen);
    }
    private void OnEnable() {
        SetDefaultMap();
    }
    void SetDefaultMap() {
        if (thisMapToChoose == default(MapToChoose)) {
            Show(this.redFrame);
        }
    }
    void ChangerMapChosen() {
        GameManager.Instance.ChangeMapChosen(thisMapToChoose);
        Show(this.redFrame);
        SpecialUnityEvent.Instance.changeMapToChoose?.Invoke(thisMapToChoose);
    }
    void ListenOnetherChosen(MapToChoose mapChoose) { 
        if (mapChoose != thisMapToChoose) 
            Hide(this.redFrame);
    }
    private void OnDisable() {
        Hide(this.redFrame);
    }
}
