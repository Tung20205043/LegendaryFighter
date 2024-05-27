using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager> {
    public GameDifficult gameDifficult;
    public GameMode gameMode;

    public bool onMusic = false;
    public bool onSound = false;
    public bool onNotify = false;
    public bool onHaptic = false;
}
