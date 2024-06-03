using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingletonPersistent<GameManager> {
    public GameDifficult gameDifficult;
    public GameMode gameMode;

    public bool onMusic = false;
    public bool onSound = false;
    public bool onNotify = false;
    public bool onHaptic = false;

    public CharacterToChoose playerChosen;
    public CharacterToChoose enemyChosen;

    public MapToChoose mapChosen;

    //
    //           _.-/`)
    //          // / / )
    //       .-// / / / )
    //      //`/ / / / / )
    //     // /       ` /
    //    ||           /
    //     \\         /
    //      ))      .`
    //     //      /
    //            /
}
