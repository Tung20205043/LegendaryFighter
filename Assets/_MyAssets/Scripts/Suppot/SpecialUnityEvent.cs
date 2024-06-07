using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecialUnityEvent : MonoBehaviourSingleton<SpecialUnityEvent>
{
    public UnityEvent setActiveHeavyPunchButton;
    public UnityEvent doComboPunch;
    public UnityEvent<int> doTransform;
    public UnityEvent<int> enemyDoTransform;
    public UnityEvent backToMainUI;
    public UnityEvent<GameObject> pressNextButton;
    public UnityEvent<GameObject> goToShopButton;
    public UnityEvent spawnCoin;
    public UnityEvent readyToFight;
    public UnityEvent <CharacterToChoose> changePlayerChoose;
    public UnityEvent <MapToChoose> changeMapToChoose;
    public UnityEvent playerIsReady;
    public UnityEvent enemyIsReady;
    public UnityEvent<float> switchCam;

    public UnityEvent newTourGame;
    public UnityEvent endCoinRoad;
    public UnityEvent<CharacterToChoose> changeCharToBuy;
    public UnityEvent<int> charPrice;

    public UnityEvent<int> setActiveUnlockPanel;
    public UnityEvent<CharacterToChoose> unlockCharacter;
}
