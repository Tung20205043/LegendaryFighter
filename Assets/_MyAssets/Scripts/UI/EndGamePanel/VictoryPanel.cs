using System;
using UnityEngine;
using UnityEngine.UI;

public class VictoryPanel : MonoBehaviour
{
    [SerializeField] private Button claimButton;
    [SerializeField] private Button x2Button;

    private void Awake()
    {
        claimButton.onClick.AddListener(OnClickClaimButton);
    }

    private void OnEnable()
    {
        SpecialUnityEvent.Instance.endGame?.Invoke();
    }

    private void OnClickClaimButton()
    {
        SpecialUnityEvent.Instance.spawnCoin?.Invoke();
        //claimButton.interactable = false;
        //x2Button.interactable = false;
    }

    private void OnDisable()
    {
        claimButton.interactable = true;
        x2Button.interactable = true;
    }
}
