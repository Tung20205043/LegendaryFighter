using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviourSingleton<GameModeManager>
{
    public GameMode currentGameMode;

    private void Awake() {
        currentGameMode = GameMode.Train;
    }
}
