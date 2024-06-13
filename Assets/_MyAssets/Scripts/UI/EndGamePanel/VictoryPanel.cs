using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameUltis;
public class VictoryPanel : MonoBehaviour
{
    [SerializeField] private Button claimButton;
    [SerializeField] private Button x2Button;
    [SerializeField] private GameObject coinBoj;
    [SerializeField] private TextMeshProUGUI rewardValue;

    private void Awake()
    {
        claimButton.onClick.AddListener(OnClickClaimButton);
    }

    private void OnEnable()
    {
        rewardValue.text = GameRewardManager.Instance.RewardValue.ToString();
    }

    private void OnClickClaimButton()
    {
        Show(coinBoj);
        SpecialUnityEvent.Instance.spawnCoin?.Invoke();
        claimButton.interactable = false;
        x2Button.interactable = false;
        Invoke(nameof(LoadNewScene), 4f);
    }
    private void LoadNewScene()
    {
        SceneManager.LoadScene(0);
    }
    private void OnDisable()
    {
        claimButton.interactable = true;
        x2Button.interactable = true;
    }
}
