using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRewardManager : MonoBehaviourSingletonPersistent<GameRewardManager>
{
    public int RewardValue { get; private set; } = 100;
    public void UpdateRewardValue (int value)
    {
        RewardValue = value;
    }
}
