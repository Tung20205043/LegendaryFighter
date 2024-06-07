using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameUltis;

public class ShowImgPrice : MonoBehaviour
{
    [System.Serializable]
    public struct UIObject {
        public CharacterToChoose key;
        public GameObject[] imgs;
    }
    [SerializeField] private List<UIObject> uIObjectList;

    private void Start() {
        SpecialUnityEvent.Instance.changeCharToBuy.AddListener(ShowUI);
    }
    void ShowUI(CharacterToChoose characterToChoose) {
        foreach (UIObject uiObj in uIObjectList) {
            if (uiObj.key.Equals(characterToChoose)) {
                ShowAllObjInArray(uiObj.imgs);
            } else {
                HideAllObjInArray(uiObj.imgs);
            }
        }
    }
    void ShowAllObjInArray(GameObject[] objs) {
        foreach (GameObject obj in objs) {
            Show(obj);
        }
    }
    void HideAllObjInArray(GameObject[] objs) {
        foreach (GameObject obj in objs) {
            Hide(obj);
        }
    }
}
