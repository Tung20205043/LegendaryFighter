using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CharacterStats.Instance.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
