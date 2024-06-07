using UnityEngine;
using UnityEngine.UI;
using static GameUltis;

public class SkinShopUI : UIParent {
    [SerializeField] Button unlockButton;
    private CharacterToChoose _charToUnlock;
    public static int price;
    [SerializeField] private GameObject notiSuccess;
    [SerializeField] private GameObject notiFail;
    protected override void Awake() {
        base.Awake();
        unlockButton.onClick.AddListener(UnlockCharacter);
    }
    private void Start() {
        SpecialUnityEvent.Instance.changeCharToBuy.AddListener(UpdateCharacterWillBuy);
        SpecialUnityEvent.Instance.charPrice.AddListener(UpdatePrice);
    }

    private void OnEnable()
    {
        SpecialUnityEvent.Instance.changeCharToBuy?.Invoke(CharUnlockManager.Instance.FirstElementInArray());
    }

    private void Update()
    {
        if (!CharUnlockManager.Instance.HaveCharToUnlock())
        {
            Hide(unlockButton.gameObject);
        }
    }

    void UpdateCharacterWillBuy(CharacterToChoose character)
    {
        _charToUnlock = character;
    }
    void UpdatePrice(int newPrice)
    {
        price = newPrice;
    }
    void UnlockCharacter() {
        if (!CharUnlockManager.Instance.HaveCharToUnlock()) return;
        if (CurrencyManager.Instance.CurrentCoin >= price) {
            CurrencyManager.Instance.ChangeCoin(-price);
            Show(notiSuccess);
            SpecialUnityEvent.Instance.unlockCharacter?.Invoke(_charToUnlock);
            CharUnlockManager.Instance.UnlockCharacter(_charToUnlock);
            ShowDefaultUI();
        }
        else
        {
            Show(notiFail);
        }
    }

    void ShowDefaultUI()
    {
        if (CharUnlockManager.Instance.FirstElementInArray() != CharacterToChoose.Default)
        {
            SpecialUnityEvent.Instance.changeCharToBuy?.Invoke(CharUnlockManager.Instance.FirstElementInArray());
        }
        else
        {
            SpecialUnityEvent.Instance.changeCharToBuy?.Invoke(CharacterToChoose.Default);
        }
    }
}
