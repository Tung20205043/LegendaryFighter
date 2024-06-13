using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingletonPersistent<GameManager>
{
    public GameDifficult GameDifficult { get; private set; }
    public GameMode GameMode { get; private set; }

    public bool onMusic = false;
    public bool onSound = false;
    public bool onNotify = false;
    public bool onHaptic = false;
    public CharacterToChoose PlayerChosen { get; private set; }

    public CharacterToChoose EnemyChosen { get; private set; }
    public MapToChoose MapChosen { get; private set; }

    public void ChangeGameMode(GameMode newMode)
    {
        this.GameMode = newMode;
    }

    public void ChangeGameDifficult(GameDifficult newGameDifficult)
    {
        this.GameDifficult = newGameDifficult;
    }

    public void ChangePlayerChosen(CharacterToChoose newPlayer)
    {
        this.PlayerChosen = newPlayer;
    }

    public void ChangerEnemyChosen(CharacterToChoose newEnemy)
    {
        this.EnemyChosen = newEnemy;
    }

    public void ChangeMapChosen(MapToChoose newMap)
    {
        this.MapChosen = newMap;
    }
}

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

